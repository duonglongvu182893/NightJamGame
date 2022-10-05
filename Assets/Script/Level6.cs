using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level6 : MonoBehaviour
{
    public static Level6 instance;

    public GameObject Player;
    public Vector2 sizeOfLevel6;
    public TextMeshProUGUI text;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setUpLevel6();
    }
    private void OnEnable()
    {
        transform.position = new Vector3(0, 3, 0);
    }

    //create map NxN
    [System.Obsolete]
    public void createMatrixNxN(Vector2 size)
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GenMap.instance.board[Mathf.FloorToInt(i + j * size.x)].isVisited = true;

            }
        }

        for (int i = 0; i < 3; i++)
        {
            int a = Random.RandomRange(0, Mathf.FloorToInt(size.x));
            int b = Random.RandomRange(0, Mathf.FloorToInt(size.y));
            GenMap.instance.board[Mathf.FloorToInt(a+ b * size.x)].choosenBrick = true;
            Debug.Log(a + b * size.x);
        }

    }

    //check Win level6
    public void setUpLevel6()
    {
        for(int i = 0; i < sizeOfLevel6.x; i++)
        {
            for(int j = 0; j < sizeOfLevel6.x; j++)
            {
                if(GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].istouch&& GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].choosenBrick)
                {
                    Debug.Log("da chon dung");
                }
            }
        }
    }
    //[System.Obsolete]
    //public void level6Color()
    //{
    //    for(int i = 0; i < 3; i++)
    //    {
    //        int a = Random.RandomRange(0, GenMap.instance.board.Count);
    //        Debug.Log(a);
    //    }
    //}
}
