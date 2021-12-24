using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShotWall : MonoBehaviour
{
    Vector3 startPos;
    float time;
    Vector3 vel;
    bool canMove;
    GameObject target;
    public LayerMask wallLayers;
    private void Update()
    {
        GetComponent<BoxCollider>().isTrigger = FindObjectOfType<ZeldaMovement>().hasHookshot;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (!other.gameObject.GetComponent<ZeldaMovement>())
            return;

        time = 0;
        startPos = other.gameObject.transform.position;

        RaycastHit hit;
        Vector3 rayPos;
        Physics.Raycast(startPos, FindObjectOfType<PlayerLookAt>().gameObject.transform.forward, out hit, 25, wallLayers);
        rayPos = hit.point;
        Debug.Log("NAME IS " + hit.transform.gameObject.name);
        canMove = (hit.transform.gameObject.name == "CanHookShotWall");
        target = hit.transform.gameObject;
        FindObjectOfType<PlayerLookAt>().transform.LookAt(target.transform);
        Vector3 fw = FindObjectOfType<PlayerLookAt>().gameObject.transform.forward;
        fw.y = 0;
        vel = fw;
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponent<LineRenderer>().SetPosition(0, new Vector3(-100, -100, -100));
        GetComponent<LineRenderer>().SetPosition(1, new Vector3(-100, -100, -100));
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (!other.gameObject.GetComponent<ZeldaMovement>())
            return;
        if (!canMove)
        {
            other.gameObject.transform.position = startPos - FindObjectOfType<PlayerLookAt>().gameObject.transform.forward;
            return;
        }
        time += Time.deltaTime * 3;
        
        Vector3 pos = other.transform.position;
        pos = startPos + (vel * time)*5;
        pos.y = 34;
        other.transform.position = pos;
        GetComponent<LineRenderer>().SetPosition(0, pos);
        Vector3 rayPos;
        RaycastHit hit;
        FindObjectOfType<PlayerLookAt>().transform.LookAt(target.transform);
        Vector3 fw = FindObjectOfType<PlayerLookAt>().gameObject.transform.forward;
        fw.y = 0;
        Physics.Raycast(pos, fw, out hit);
        rayPos = hit.point;
        GetComponent<LineRenderer>().SetPosition(1, rayPos);
    }
}
