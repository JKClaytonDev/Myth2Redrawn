using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShieldScript : MonoBehaviour
{
    public GameObject g;


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (!collision.gameObject.GetComponent<ZeldaMovement>().hasTorch)
                return;
            transform.localScale /= 1 + Time.deltaTime;
            if (transform.localScale.x < 0.1f)
                Destroy(gameObject);

        }
    }
}
