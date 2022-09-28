using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{

    public static Level4 instance;
    public Vector2 sizeOfLevel4;


    public int[] countRow = new int[4];
    public int[] countColumn = new int[4];
    public int[] countMainDiagonal = new int[4];
    public bool[] row = new bool[4];
    public bool[] column = new bool[4];
    public bool[] mainDiagonal = new bool[4];


    public int sum = 0;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            countColumn[i] = 0;
            countRow[i] = 0;
            countMainDiagonal[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void createMatrixNxN(Vector2 size)
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GenMap.instance.board[Mathf.FloorToInt(i + j * size.x)].isVisited = true;
            }
        }
        GenMap.instance.board[Mathf.FloorToInt(0 + 0 * size.x)].istouch = true;
        GenMap.instance.board[Mathf.FloorToInt(1 + 0 * size.x)].istouch = true;
    }
    public void check(Vector2 size)
    {
        //check duong ngang i khong thay doi

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (GenMap.instance.board[Mathf.FloorToInt(i + j * size.x)].istouch)
                {
                    countRow[i] += 1;
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (countRow[i] > 1)
            {
                row[i] = true;
            }
        }
        //check hang j khong doi
        for(int i = 0; i < size.y; i++)
        {
            for(int j = 0; j < size.x; j++)
            {
                if (GenMap.instance.board[(Mathf.FloorToInt(j + i * size.x))].istouch)
                {
                    countColumn[i] = countColumn[i] + 1;
                }
            }
        }
        for(int i = 0; i < 4; i++)
        {
            if (countColumn[i] > 1)
            {
                column[i] = true;
            }
        }
        //check duong cheo chinh
        for(int i = 0; i < size.x; i++)
        {
            if(GenMap.instance.board[(Mathf.FloorToInt(i + i * size.x))].istouch)
            {
                countMainDiagonal[i] = countMainDiagonal[i] + 1;
            }
        }
    }
    
    public void checkWin()
    {
        for (int i = 0; i < 4; i++)
        {
            if (row[i])
            {
                Debug.Log("vi pham o hang" + i);
                break;
            }
            if (column[i])
            {
                Debug.Log("vi pham o cot" + i);
                break;
            }
            if (mainDiagonal[i])
            {
                Debug.Log("vi pham o duong cheo thu" + i);
                break;
            }
            if (!row[i])
            {
                Debug.Log("hop le o hang" + i);
                
            }
            if (!column[i])
            {
                Debug.Log("hop le o cot" + i);
               
            }
            if (!mainDiagonal[i])
            {
                Debug.Log("duong cheo " + i + " hop le");
            }
        }
    }
}
