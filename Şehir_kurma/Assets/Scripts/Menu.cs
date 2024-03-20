using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        // Oyun sahnesini y�kle
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        // Oyundan ��k�� yap
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void MenuScene()
    {
        // Oyun sahnesini y�kle
        SceneManager.LoadScene("SimplePoly City - Low Poly Assets_Demo Scene");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
    }
}
