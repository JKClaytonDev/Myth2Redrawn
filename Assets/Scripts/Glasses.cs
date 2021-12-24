using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float pos = Input.mousePosition.x/300;
        Vector3 localPos = new Vector3(pos, 0, 0);
        cam1.transform.localPosition = localPos;
        cam2.transform.localPosition = -localPos;
    }
}
