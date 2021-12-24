using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DiamondScript : MonoBehaviour
{
    ZeldaMovement zelda;
    // Start is called before the first frame update
    void Start()
    {
        zelda = FindObjectOfType<ZeldaMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
        GetComponent<BoxCollider>().isTrigger = zelda.puzzleCount == 5;
        if (zelda.puzzleCount == 5)
            transform.Rotate(0, Time.deltaTime * 30, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ZeldaMovement>())
            SceneManager.LoadScene("EndCutscene");
    }
}
