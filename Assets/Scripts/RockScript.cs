using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public GameObject g;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (!collision.gameObject.GetComponent<ZeldaMovement>().hasBoom)
                return;
            GetComponent<MeshCollider>().enabled = false;
            g.transform.parent = null;
            g.SetActive(true);
            Destroy(gameObject);

        }
    }
}
