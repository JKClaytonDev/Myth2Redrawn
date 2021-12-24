using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    public Vector3 targetPos;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 150);
        if (Mathf.Round(targetPos.x) == Mathf.Round(6.08f) && Mathf.Round(targetPos.z) == Mathf.Round(21.3f))
            FindObjectOfType<ZeldaMovement>().breatheTime = Time.realtimeSinceStartup + 0.2f;
    }
}
