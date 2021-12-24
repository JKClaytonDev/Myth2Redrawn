using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBossScript : MonoBehaviour
{
    public Animator anim;
    public GameObject fightCanvas;
    public Sprite bossImage;
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasBucket)
            {
                if (GetComponent<BoxCollider>())
                    Destroy(GetComponent<BoxCollider>());
                if (GetComponent<SphereCollider>())
                    Destroy(GetComponent<SphereCollider>());
                Time.timeScale = 0.01f;
                GameObject k = Instantiate(fightCanvas);
                FindObjectOfType<BossBattle>().startCount = 4;
                FindObjectOfType<BossBattle>().StartDifficulty = 5;
                FindObjectOfType<BossBattle>().setDifficulty(bossImage, new Vector3(3, 3, 1));
                anim.Play("KillBoss");
                Destroy(gameObject, 1.1f);
            }

        }
    }
}
