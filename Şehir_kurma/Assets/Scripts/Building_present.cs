using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="Building preset",menuName ="New Building preset")]
public class Building_present : ScriptableObject
{
    public int cost;
    public int costPerTurn;
    public GameObject prefab;

    public int Population;
    public int Jobs;
    public int food; 

}
