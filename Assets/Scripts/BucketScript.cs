using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    Animator anim;
    public GameObject prompt;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (!collision.gameObject.GetComponent<ZeldaMovement>().hasBucket)
            {
                GameObject k = Instantiate(prompt);
                k.transform.parent = null;
                collision.gameObject.GetComponent<ZeldaMovement>().hasBucket = true;
                GetComponent<BoxCollider>().enabled = false;
                anim.Play("TakeBucket");
                Destroy(gameObject, 1.1f);
            }

        }
    }
}
