using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject wall;
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            wall.transform.position -= Vector3.up * 5 * Time.deltaTime;

        }
    }

}
