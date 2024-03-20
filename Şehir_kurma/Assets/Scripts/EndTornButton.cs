using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTornButton : MonoBehaviour
{
    public GameObject targetObject; // Etkinleþtirilecek hedef nesne
    private bool isActive = false; // Hedef nesnenin etkin olup olmadýðýný tutar

    // Butonun bir iþlevi çaðýrmasýný saðlayan fonksiyon
    public void ToggleTargetObject()
    {
        // Hedef nesneyi etkinleþtir veya devre dýþý býrak
        if (targetObject != null)
        {
            isActive = !isActive; // Durumu tersine çevir
            targetObject.SetActive(isActive);
        }
        else
        {
            Debug.LogError("Hedef nesne atanmamýþ!");
        }
    }
}
