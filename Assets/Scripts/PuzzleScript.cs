using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
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
            anim.Play("TakePuzzle");
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 1.1f);
            collision.gameObject.GetComponent<ZeldaMovement>().puzzleCount++;
        }
    }

}
