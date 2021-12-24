using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShotScript : MonoBehaviour
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
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasHookshot)
                return;
            GameObject k = Instantiate(prompt);
            k.transform.parent = null;
            collision.gameObject.GetComponent<ZeldaMovement>().hasHookshot = true;
            anim.Play("TakeHookShot");
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 0.35f);
        }
    }
}
