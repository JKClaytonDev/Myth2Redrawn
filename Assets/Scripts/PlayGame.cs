using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayGame : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene("Myth2");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
