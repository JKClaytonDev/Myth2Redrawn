using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    float camTime;
    public AudioSource music;
    public AudioClip[] walkSounds;

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.GetComponent<ZeldaMovement>())
            return;
        camTime = Time.realtimeSinceStartup + 0.1f;
        FindObjectOfType<MainCam>().targetPos = transform.position+Vector3.up*16;
        other.gameObject.GetComponent<ZeldaMovement>().walkSounds = walkSounds;
    }
    void Update()
    {
        if (FindObjectOfType<BossBattle>())
        {
            music.volume = 0;
            return;
        }

        if (!music)
            music = GetComponent<AudioSource>();
        music.volume -= Time.deltaTime*5;
        if (camTime > Time.realtimeSinceStartup)
            music.volume = PlayerPrefs.GetInt("Music");
        if (PlayerPrefs.GetInt("Music") == 0)
            music.volume = 0;
    }
}
