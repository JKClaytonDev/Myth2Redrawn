using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("Music");
    }
}
