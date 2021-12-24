using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnMenu : MonoBehaviour
{
    public void SetGraphics(int i)
    {
        QualitySettings.SetQualityLevel(i);
    }
    public void exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Fullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void Music()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
            PlayerPrefs.SetInt("Music", 1);
        else
            PlayerPrefs.SetInt("Music", 0);
        PlayerPrefs.Save();
    }
}
