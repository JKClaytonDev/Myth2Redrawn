using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    Animator anim;
    public GameObject prompt;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasMagnet)
                return;
            GameObject k = Instantiate(prompt);
            k.transform.parent = null;
            collision.gameObject.GetComponent<ZeldaMovement>().hasMagnet = true;
            anim.Play("TakeMagnet");
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 0.4f);
        }
    }
}
