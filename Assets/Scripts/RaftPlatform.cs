using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPlatform : MonoBehaviour
{
    public GameObject raft;
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (!collision.gameObject.GetComponent<ZeldaMovement>().hasRaft)
                return;
            Vector3 scale = transform.localScale;
            scale.y = 1;
            transform.localScale = scale;
            raft.gameObject.SetActive(true);
            Vector3 pos = collision.transform.position;
            pos.y = raft.transform.position.y;
            raft.transform.position = pos;
        }
    }
}
