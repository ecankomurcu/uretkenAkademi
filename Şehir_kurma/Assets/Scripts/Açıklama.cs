using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Açıklama : MonoBehaviour
{
    // Butona basıldığında çalışacak fonksiyon
    public void DeleteSelf()
    {
        // Kendi oyun nesnesini yok et
        Destroy(gameObject);
    }
}
