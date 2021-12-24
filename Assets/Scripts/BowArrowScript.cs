using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowArrowScript : MonoBehaviour
{
    public GameObject prompt;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<ZeldaMovement>())
        {
            if (!collision.gameObject.GetComponent<ZeldaMovement>().hasBow)
            {
                GameObject k = Instantiate(prompt);
                k.transform.parent = null;
                collision.gameObject.GetComponent<ZeldaMovement>().hasBow = true;
                Destroy(gameObject);
            }

        }
    }

}
