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
        setPosition();

        if (PlayerWhenStart.instance.level == 4) 
        {
            GenMapWithPosition(i, j, Level4.instance.sizeOfLevel4);
        }
        else if(PlayerWhenStart.instance.level != 4)
        {
            GenMapWithPosition(i, j, Level5.instance.sizeOfLevel5);

        }
        //else if(PlayerWhenStart.instance.level!=4&& PlayerWhenStart.instance.level!=5)
        //{
        //    GenMapWithPosition(i, j, Level6.instance.sizeOfLevel6);
        //}


        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
    }


    private void OnEnable()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
    }
    void setPosition()
    {
        if (Mathf.Round(transform.position.x) < 0)
        {
            i = -(Mathf.FloorToInt(Mathf.Round(transform.position.x) / 3));
        }
        else if (Mathf.Round(transform.position.x) > 0)
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

    }
    void GenMapWithPosition(int i , int j , Vector2 size)
    {
        GenMap.instance.setTouch(i, j, size);
    }
}
