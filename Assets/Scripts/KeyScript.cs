using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
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
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasKey)
                return;
            anim.Play("TakeKey");
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 1.1f);
            collision.gameObject.GetComponent<ZeldaMovement>().hasKey = true;

        }
    }
}
