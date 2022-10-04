using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forwardColider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Player" && other.transform.tag != "check")
        {
            PlayerController.instance.isBlockFoward = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag != "Player" && other.transform.tag != "check")
        {
            PlayerController.instance.isBlockFoward = false;
        }
    }
}
