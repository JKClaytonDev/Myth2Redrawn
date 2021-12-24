using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    public void kill()
    {
        if (anim)
        anim.Play("BatDie");
        Destroy(gameObject, 0.51f);
    }

}
