using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdBreath : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("TRIGGERED");
        if (other.GetComponent<ZeldaMovement>())
            other.GetComponent<ZeldaMovement>().breatheTime = Time.realtimeSinceStartup + 0.2f;
    }
}
