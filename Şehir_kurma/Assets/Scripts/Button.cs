using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public GameObject targetObject; // Etkinle�tirilecek hedef nesne
    private bool isActive = false; // Hedef nesnenin etkin olup olmad���n� tutar

    // Butonun bir i�levi �a��rmas�n� sa�layan fonksiyon
    public void ToggleTargetObject()
    {
        // Hedef nesneyi etkinle�tir veya devre d��� b�rak
        if (targetObject != null)
        {
            isActive = !isActive; // Durumu tersine �evir
            targetObject.SetActive(isActive);
        }
        else
        {
            Debug.LogError("Hedef nesne atanmam��!");
        }
    }

}
