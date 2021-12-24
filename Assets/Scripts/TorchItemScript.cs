using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchItemScript : MonoBehaviour
{
    public GameObject prompt;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasTorch)
                return;
            GameObject k = Instantiate(prompt);
            k.transform.parent = null;
            collision.gameObject.GetComponent<ZeldaMovement>().hasTorch = true;
            anim.Play("TakeTorch");
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 1.05f);
        }
    }
}
