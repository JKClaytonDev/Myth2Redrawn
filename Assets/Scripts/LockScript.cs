using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (!collision.gameObject.GetComponent<ZeldaMovement>().hasKey)
                anim.Play("Locked");
            else
            {
                GetComponent<BoxCollider>().enabled = false;
                anim.Play("Unlock");
                collision.gameObject.GetComponent<ZeldaMovement>().hasKey = false;
                Destroy(gameObject, 1.1f);
            }

        }
    }
}
