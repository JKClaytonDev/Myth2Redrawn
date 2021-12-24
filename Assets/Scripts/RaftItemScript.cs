using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftItemScript : MonoBehaviour
{
    public GameObject prompt;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject k = Instantiate(prompt);
        k.transform.parent = null;
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (collision.gameObject.GetComponent<ZeldaMovement>().hasRaft)
                return;
            collision.gameObject.GetComponent<ZeldaMovement>().hasRaft = true;
            anim.Play("TakeRaft");
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 0.35f);
        }
    }
}
