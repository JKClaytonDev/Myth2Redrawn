using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeldaMovement : MonoBehaviour
{
    public bool firstPerson;
    public int equipped = 0;
    public int puzzleCount = 0;
    public bool hasSword;
    public GameObject sword;
    public Animator swordAnim;
    public bool hasKey;
    public GameObject keyItem;
    public bool hasBucket;
    public bool hasBow;
    public GameObject bow;
    public bool hasMagnet;
    public GameObject magnet;
    public bool hasHookshot;
    public GameObject hookShot;
    public bool hasRaft;
    public bool hasTorch;
    public bool hasBoom;
    public bool hasHook;
    MainCam cam;
    public float breatheTime;
    public GameObject breathObj;

    public AudioClip[] walkSounds;
    public Vector3 lastWalkPos;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
            PlayerPrefs.SetInt("Music", 1);
        Time.timeScale = 1;
        cam = FindObjectOfType<MainCam>();
    }
    public void Swing(Transform t)
    {
        sword.transform.LookAt(t);
        sword.transform.Rotate(0, 0, 0);
        swordAnim.Play("SwingSword");
    }
    // Update is called once per frame
    void Update()
    {
        breathObj.SetActive(Time.realtimeSinceStartup < breatheTime);
        if (Vector3.Distance(transform.position, lastWalkPos) > 5)
        {
            GetComponent<AudioSource>().PlayOneShot(walkSounds[Random.Range(0, walkSounds.Length-1)]);
            lastWalkPos = transform.position;
        }
        if (cam.targetPos != cam.transform.position)
            return;
        bow.SetActive(hasBow);
        if (hasBow && Input.GetKey(KeyCode.Space))
            return;
        keyItem.SetActive(hasKey);
        if (firstPerson)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * 180 * Time.deltaTime, 0);
            FindObjectOfType<PlayerLookAt>().enabled = false;
            FindObjectOfType<PlayerLookAt>().gameObject.transform.localEulerAngles = new Vector3();
            GetComponent<Rigidbody>().velocity = transform.forward*Input.GetAxis("Vertical")*10;
        }
        else
            GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Horizontal") * -10, 0, Input.GetAxis("Vertical") * -10);
    }
}
