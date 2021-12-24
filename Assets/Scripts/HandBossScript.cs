using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBossScript : MonoBehaviour
{
    public GameObject colliderObject;
    public Animator anim;
    public GameObject fightCanvas;
    public Sprite bossImage;
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasMagnet)
            {
                if (GetComponent<BoxCollider>())
                    Destroy(GetComponent<BoxCollider>());
                if (GetComponent<SphereCollider>())
                    Destroy(GetComponent<SphereCollider>());
                Time.timeScale = 0.01f;
                GameObject k = Instantiate(fightCanvas);
                FindObjectOfType<BossBattle>().startCount = 7;
                FindObjectOfType<BossBattle>().StartDifficulty = 6;
                FindObjectOfType<BossBattle>().setDifficulty(bossImage, new Vector3(2, 3, 1));
                anim.Play("HandDie");
                Destroy(colliderObject, 0.5f);
            }

        }
    }
}
