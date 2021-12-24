using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    Animator anim;
    public GameObject prompt;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (!collision.gameObject.GetComponent<ZeldaMovement>().hasSword)
            {
                GameObject k = Instantiate(prompt);
                k.transform.parent = null;
                collision.gameObject.GetComponent<ZeldaMovement>().hasSword = true;
                GetComponent<BoxCollider>().enabled = false;
                anim.Play("TakeSword");
                Destroy(gameObject, 1.1f);
            }

        }
    }
}
