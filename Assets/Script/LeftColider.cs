using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftColider : MonoBehaviour
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
            PlayerController.instance.isBlockOnTheLeft = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag != "Player" && other.transform.tag != "check")
        {
            PlayerController.instance.isBlockOnTheLeft = false;
        }
    }
}
