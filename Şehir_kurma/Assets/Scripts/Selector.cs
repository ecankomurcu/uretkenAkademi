using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Selector : MonoBehaviour
{
    private Camera cam;
    public static Selector instance;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        cam = Camera.main;
       
    }

    public Vector3 GetCurTilePosition()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return new Vector3(0, -99, 0);

        }

        Plane plane = new Plane(Vector3.up, Vector3.zero);        
       Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        float rayout = 0.0f;

        if(plane.Raycast(ray,out rayout))
        {
            Vector3 newpos = ray.GetPoint(rayout)-new Vector3(0.05f,0.0f,0.05f);
            newpos = new Vector3(Mathf.CeilToInt(newpos.x), 0.0f, Mathf.CeilToInt(newpos.z));
            return newpos;
        }

        return new Vector3(0, -99, 0);
    }

}
