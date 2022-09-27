using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGate : MonoBehaviour
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
        if (other.transform.tag == "Player" || other.transform.tag == "Clone")
        {
            //GenMap.instance.enableBrick();
            StartCoroutine(GenMap.instance.delayEnable());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Clone")
        {
            //GenMap.instance.disableBrick();
            StartCoroutine(GenMap.instance.delayDiable());
        }
    }
}
