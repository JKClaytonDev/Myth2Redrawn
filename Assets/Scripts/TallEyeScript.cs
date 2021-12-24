using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallEyeScript : MonoBehaviour
{
    public Animator anim;
    public GameObject parent;
    ZeldaMovement player;
    public BoxCollider b;
    public GameObject fightCanvas;
    public Sprite bossImage;

    // Start is called before the first frame update
    public void kill()
    {
        if (GetComponent<BoxCollider>())
            Destroy(GetComponent<BoxCollider>());
        if (GetComponent<SphereCollider>())
            Destroy(GetComponent<SphereCollider>());
        Time.timeScale = 0.01f;
        GameObject k = Instantiate(fightCanvas);
        FindObjectOfType<BossBattle>().startCount = 2;
        FindObjectOfType<BossBattle>().StartDifficulty = 5;
        FindObjectOfType<BossBattle>().setDifficulty(bossImage, new Vector3(2, 3, 1));
        anim.Play("DieTallBoss");
        Destroy(b, 1);
        Destroy(parent, 2.5f);
        this.enabled = false;
    }
    private void Update()
    {
     if (!player)
        {
            player = FindObjectOfType<ZeldaMovement>();
        }
        anim.speed = 0;
        if (player.hasBow)
            anim.speed = 1;
    }
}
