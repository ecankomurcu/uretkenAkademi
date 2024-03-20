using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDönme : MonoBehaviour
{
    public Transform target; // Kameranın bakacağı hedef nesne
    public float rotationSpeed = 5f; // Dönme hızı

    void Update()
    {
        // Hedef nesnenin etrafında 360 derece dönme
        if (target != null)
        {
            transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogError("Hedef nesne atanmamış!");
        }
    }
}
