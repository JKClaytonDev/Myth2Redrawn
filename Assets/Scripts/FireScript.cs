using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
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
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasBucket)
            {
                GetComponent<BoxCollider>().enabled = false;
                anim.Play("PourWater");
                Destroy(gameObject, 1.3f);
            }

        }
    }
}
