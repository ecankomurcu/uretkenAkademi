using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_pleasment : MonoBehaviour
{
    private bool currentlyPlacing;
    private bool currentlyBulldozer;

    private Building_present curBuildingPresent;

    private float indicatorUpdateTime = 0.05f;

    private float lastUpdateTime;
    private Vector3 curIndicatorPos;

    public GameObject placementIndicator;
    public GameObject bulldozerIndicator;

    public void BeginNewBuildingPlacement(Building_present _Present)
    {
        currentlyPlacing = true;
        curBuildingPresent = _Present;
        placementIndicator.SetActive(true);
    }

    void CancelBuildingPlacement()
    {
        currentlyPlacing = false;
        currentlyBulldozer = false;
        placementIndicator.SetActive(false);
        bulldozerIndicator.SetActive(false);
    }

    public void ToggleBulldoze()
    {
        currentlyBulldozer = !currentlyBulldozer;
        bulldozerIndicator.SetActive(currentlyBulldozer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CancelBuildingPlacement();

        if (Time.time - lastUpdateTime > indicatorUpdateTime)
        {
            lastUpdateTime = Time.time;
            curIndicatorPos = Selector.instance.GetCurTilePosition();

            if (currentlyPlacing)
                placementIndicator.transform.position = curIndicatorPos;
            else if (currentlyBulldozer)
            {
                bulldozerIndicator.transform.position = curIndicatorPos;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentlyPlacing)
                PlaceBuilding();
            else if (currentlyBulldozer)
                Bulldoze();
        }
    }

    void PlaceBuilding()
    {
        GameObject buildingObj = Instantiate(curBuildingPresent.prefab, curIndicatorPos, Quaternion.identity);
        City.instance.onPlaceBuilding(buildingObj.GetComponent<Building>());
        CancelBuildingPlacement();
    }

    void Bulldoze()
    {
        Building buildingToDestroy = City.instance.buildings.Find(x => x.transform.position == curIndicatorPos);
        if (buildingToDestroy != null)
        {
            City.instance.OnRemoveBuilding(buildingToDestroy);
        }
    }
}
