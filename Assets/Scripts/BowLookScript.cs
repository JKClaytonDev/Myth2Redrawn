using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowLookScript : MonoBehaviour
{
    public Camera c;
    public GameObject bow;
    public GameObject player;
    public GameObject arrow;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<arrowScript>())
        GetComponent<arrowScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 1)
            return;
        bow.SetActive(Input.GetKey(KeyCode.Space));
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (FindObjectOfType<ZeldaMovement>().firstPerson)
                transform.localEulerAngles = new Vector3();
            GameObject k = Instantiate(arrow);
            k.gameObject.SetActive(true);
            k.gameObject.AddComponent<arrowScript>();
            k.transform.parent = null;
            k.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            k.transform.position = arrow.transform.position;
            k.gameObject.GetComponent<BoxCollider>().enabled = true;
            k.gameObject.GetComponent<AudioSource>().enabled = true;
            k.transform.rotation = arrow.transform.rotation;
            k.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            k.GetComponent<arrowScript>().enabled = true;
            k.GetComponent<Rigidbody>().velocity = k.transform.up*15;
        }
        if (!Input.GetKey(KeyCode.Space))
            return;
        Vector2 move;
        move.x = -Input.GetAxis("Horizontal");
        move.y = -Input.GetAxis("Vertical");
        if (Mathf.Abs(move.y) > 0.1f || Mathf.Abs(move.x) > 0.1f)
        {
            mousePos.x = move.x;

            mousePos.y = move.y;
        }
        
        Vector3 lP = Vector3.right * mousePos.x + Vector3.forward * mousePos.y;
        transform.LookAt(transform.position + lP);

        if (FindObjectOfType<ZeldaMovement>().firstPerson)
            transform.localEulerAngles = new Vector3();
    }
}
