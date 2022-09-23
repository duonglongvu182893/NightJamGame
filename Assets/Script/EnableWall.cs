using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWall : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Transform position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enableWall();
    }
    void enableWall()
    {
        if(Vector3.Distance(position.transform.position, Player.transform.position)<5f)
        {
            PlatformControll.instance.logicMapGame();

        }
        else
        {
            PlatformControll.instance.endLogic();
        }
    }
    
}
