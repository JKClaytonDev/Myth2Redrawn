using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasSword)
            {
                collision.gameObject.GetComponent<ZeldaMovement>().Swing(transform);
                anim.Play("SkullDie");
                Destroy(gameObject, 0.85f);
            }

        }
    }

}
