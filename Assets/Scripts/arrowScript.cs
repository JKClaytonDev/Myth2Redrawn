using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    float startTime;
    private void OnEnable()
    {
        startTime = Time.realtimeSinceStartup;
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("LAYER IS" + collision.gameObject.layer);
        if (collision.gameObject.layer == 11)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.eulerAngles = new Vector3(-75, 0, 0);
            transform.position += transform.forward;
            GetComponent<Rigidbody>().velocity = transform.up * 20;
            Destroy(gameObject, 5);
            return;
        }
        if (Time.realtimeSinceStartup < startTime + 0.1f)
            return;
        if (transform.parent)
            return;
        if (collision.gameObject.GetComponent<BatScript>())
            collision.gameObject.GetComponent<BatScript>().kill();
        if (collision.gameObject.GetComponent<TallEyeScript>())
            collision.gameObject.GetComponent<TallEyeScript>().kill();
        Destroy(gameObject);
    }

}
