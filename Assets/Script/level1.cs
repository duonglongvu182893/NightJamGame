using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour
{

    public static level1 instance;
    public Vector2 sizeOfLevel1;


    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    [System.Obsolete]

    void Start()
    {
        //selectLevel1();
        //GenMap.instance.createMaze(sizeOfLevel1);
        //for (int i = 0; i < GenMap.instance.numberOfBrick.Count; i++)
        //{
        //    Debug.Log(GenMap.instance.numberOfBrick[i]);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    public void selectLevel1(Vector2 size)
    {
        //GenMap.instance.createList(size);
        for(int i = 0; i < GenMap.instance.board.Count; i++)
        {
            if (i % 2 == 0)
            {
                GenMap.instance.board[i].fallBrick = true;
            }
        }
    }
}
