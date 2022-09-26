using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Brick : MonoBehaviour
{
    Rigidbody myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {

        myRb.isKinematic = false;
    }
}
