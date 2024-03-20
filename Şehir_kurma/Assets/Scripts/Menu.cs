using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        // Oyun sahnesini yükle
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        // Oyundan çýkýþ yap
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void MenuScene()
    {
        // Oyun sahnesini yükle
        SceneManager.LoadScene("SimplePoly City - Low Poly Assets_Demo Scene");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
    }
}
