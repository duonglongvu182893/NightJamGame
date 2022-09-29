using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickPosition : MonoBehaviour
{
    int i;
    int j;
    // Start is called before the first frame update
    void Start()
    {
        //GenMap.instance.setTouch(Mathf.FloorToInt(Mathf.Round(transform.position.x)),Mathf.FloorToInt( Mathf.Round(transform.position.z)), Level4.instance.sizeOfLevel4);
        if (Mathf.Round(transform.position.x) < 0)
        {
            i = -(Mathf.FloorToInt(Mathf.Round(transform.position.x) / 3));
        }
        else if(Mathf.Round(transform.position.x) > 0)
        {
            i = Mathf.FloorToInt(Mathf.Round(transform.position.x)) / 3;
        }
        if (Mathf.Round(transform.position.z) < 0)
        {
            j = -(Mathf.FloorToInt(Mathf.Round(transform.position.z)) / 3);
        }
        else if (Mathf.Round(transform.position.z) > 0)
        {
            j = Mathf.FloorToInt(Mathf.Round(transform.position.z)) / 3;
        }
        GenMap.instance.setTouch(i, j, Level5.instance.sizeOfLevel5);
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
