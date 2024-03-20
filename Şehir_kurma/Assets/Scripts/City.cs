using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class City : MonoBehaviour
{
    public int Money;
    public int day;
    public int CurPopulation;
    public int CurJobs;
    public int CurFood;
    public int maxPopilation;
    public int maxJobs;
    public int incomPerJob;
    public TextMeshProUGUI statsText;
    public List<Building> buildings = new List<Building>();

    public static City instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdatestatsText(); 
    }
    public void onPlaceBuilding(Building building)
    {
        Money -= building.preset.cost;
        maxPopilation += building.preset.Population;
        maxJobs += building.preset.Jobs;
        buildings.Add(building);
        UpdatestatsText();
    }

    public void OnRemoveBuilding(Building building)
    {
        
        maxPopilation -= building.preset.Population;
        maxJobs -= building.preset.Jobs;
        buildings.Remove(building);
        Destroy(building.gameObject);
        UpdatestatsText();
    }

    void UpdatestatsText()
    {
        statsText.text = string.Format("Day:{0}       Money:{1}       Pop:{2} / {3}             Jobs:{4} / {5}           Food {6}", new object[7] { day, Money, CurPopulation, maxPopilation, CurJobs, maxJobs, CurFood });
    }
    public void EndTurn()
    {
        day++;
        CalculateMoney();
        CalculatePopilation();
        CalculateJobs();
        CalculateFood();
        UpdatestatsText();
    }
    void CalculateMoney()
    {
        Money += CurJobs * incomPerJob;
        foreach (Building building in buildings)
            Money -= building.preset.costPerTurn;
    }
    void CalculatePopilation()
    {
        if(CurFood>=CurPopulation&&CurPopulation<maxPopilation)
        {
            CurFood -= CurPopulation / 4;
            CurPopulation = Mathf.Min(CurPopulation + (CurFood / 4), maxPopilation);
        }
        else if(CurFood<CurPopulation)
        {
            CurPopulation = CurFood;
        }
    }
    void CalculateJobs()
    {
        CurJobs = Mathf.Min(CurPopulation, maxJobs);
    }
    void CalculateFood()
    {
        CurFood = 0;
        foreach (Building building in buildings)
            CurFood += building.preset.food;
    }
}
