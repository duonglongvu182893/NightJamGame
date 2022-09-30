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
            //Level3.instance.setActiveBrick(1);

            winCheck.instance.checkWin();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Clone")
        {
            StartCoroutine( GenMap.instance.delayDiable());
            //Level3.instance.setActiveBrick(0);
            winCheck.instance.disbaleWin();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(new Vector3(Mathf.Round(collision.transform.position.x), Mathf.Round(collision.transform.position.y), Mathf.Round(collision.transform.position.y)));
    }
}
