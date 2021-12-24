using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormScript : MonoBehaviour
{
    public GameObject fightCanvas;
    public Animator anim;
    public Sprite bossImage;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasSword)
            {
                if (GetComponent<BoxCollider>())
                    Destroy(GetComponent<BoxCollider>());
                if (GetComponent<SphereCollider>())
                    Destroy(GetComponent<SphereCollider>());
                Time.timeScale = 0.01f;
                GameObject k = Instantiate(fightCanvas);
                FindObjectOfType<BossBattle>().startCount = 2;
                FindObjectOfType<BossBattle>().StartDifficulty = 2;
                FindObjectOfType<BossBattle>().setDifficulty(bossImage, new Vector3(5, 2, 1));
                collision.gameObject.GetComponent<ZeldaMovement>().Swing(transform);
                anim.Play("WormDie");
                Destroy(gameObject, 1.1f);
                Destroy(anim.gameObject, 1.1f);
            }

        }
    }

}
