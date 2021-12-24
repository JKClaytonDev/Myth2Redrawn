using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDescription : MonoBehaviour
{
    bool start = false;
    float vel = 0;
    float startTime;
    // Update is called once per frame
    private void Start()
    {
        startTime = Time.realtimeSinceStartup + 5;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Time.realtimeSinceStartup > startTime)
            start = true;
        if (start)
        {
            vel += 120 * Time.deltaTime;
            GetComponent<RectTransform>().position -= Vector3.up * (vel*vel);
        }
    }
}
