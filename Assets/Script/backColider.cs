using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backColider : MonoBehaviour
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
        if(other.transform.tag != "Player")
        {
            PlayerController.instance.isBlockBack = true;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag != "Player")
        {
            PlayerController.instance.isBlockBack = false;
        }
    }
}
