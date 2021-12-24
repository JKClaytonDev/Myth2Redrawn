using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    Vector3 lastPos;
    float walkTime;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().speed = 0;
        if (Time.realtimeSinceStartup < walkTime)
            GetComponent<Animator>().speed = 1;
        if (transform.position != lastPos) {
            walkTime = Time.realtimeSinceStartup + 0.1f;
            GetComponent<Animator>().speed = 1;
            transform.LookAt(lastPos);
            transform.Rotate(0, 180, 0);
            lastPos = transform.position;
            Vector3 angles = transform.localEulerAngles;
            angles.x = 0;
            angles.z = 0;
            transform.localEulerAngles = angles;
                }
        
    }
}
