using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{

    public static Level4 instance;
    public Vector2 sizeOfLevel4;


    public int[] countRow = new int[4];
    public int[] countColumn = new int[4];
    public int[] countMainDownDiagonal = new int[4];
    public int[] countMainUpDiagonal = new int[4];
    public int[] countDownDiagonal = new int[4];
    public int[] countUpDiagonal = new int[4];


    public bool[] row = new bool[4];
    public bool[] column = new bool[4];
    public bool[] mainDownDiagonal = new bool[4];
    public bool[] mainUpDiagonal = new bool[4];
    public bool[] downDiagonal = new bool[4];
    public bool[] upDiagonal = new bool[4];


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
            countMainDownDiagonal[i] = 0;
            countMainUpDiagonal[i] = 0;
            countDownDiagonal[i] = 0;
            countUpDiagonal[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //GenMap.instance.board[Mathf.FloorToInt(3 + 1 * sizeOfLevel4.x)].istouch = true;
        //GenMap.instance.board[Mathf.FloorToInt(2 + 2 * sizeOfLevel4.x)].istouch = true;
        
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
        //GenMap.instance. setTouch(0, 2, Level4.instance.sizeOfLevel4);
        //GenMap.instance.setTouch(0, 1, Level4.instance.sizeOfLevel4);

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
        for (int i = 0; i < size.y; i++)
        {
            for (int j = 0; j < size.x; j++)
            {
                if (GenMap.instance.board[(Mathf.FloorToInt(j + i * size.x))].istouch)
                {
                    countColumn[i] = countColumn[i] + 1;
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (countColumn[i] > 1)
            {
                column[i] = true;
            }
        }

        //CHECK DUONG CHEO CHINH
        //phia duoi duong cheo chinh
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (Mathf.FloorToInt(j - i) >= 0)
                {
                    if (GenMap.instance.board[Mathf.FloorToInt(j + (j - i) * size.x)].istouch)
                    {
                        countMainDownDiagonal[i] += 1;
                    }
                }
                
            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (countMainDownDiagonal[i] > 1)
            {
                mainDownDiagonal[i] = true;
            }
        }
        //phia tren duong cheo chinh
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (Mathf.FloorToInt(i+j) < size.x)
                {
                    if (GenMap.instance.board[Mathf.FloorToInt(j + (j + i) * size.x)].istouch)
                    {
                        countMainUpDiagonal[i] += 1;
                    }
                }

            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (countMainUpDiagonal[i] > 1)
            {
                mainUpDiagonal[i] = true;
            }
        }

        //CHECK DUONG CHEO PHU
        //phia duoi duong cheo phu
        for (int i = 3; i >= 0; i--)
        {
            int a = i;
            for (int j = 0; j <= i; j++)
            {
                if (GenMap.instance.board[Mathf.FloorToInt(a + j * size.x)].istouch)
                {
                    countDownDiagonal[i] += 1;
                }
                a--;
            }
           
        }

        for (int i = 0; i < 4; i++)
        {
            if (countDownDiagonal[i] > 1)
            {
                downDiagonal[i] = true;
            }
        }
        //phia tren duong cheo phu
        int b = 0;
        for (int i = 3; i >= 0; i--)
        {
            int a = 3;
           
            for (int j = 1; j <= i; j++)
            {
                if (GenMap.instance.board[Mathf.FloorToInt(a + (j + b) * size.x)].istouch)
                {
                    countUpDiagonal[i] += 1;
                }
                //int x = j + b;
                //Debug.Log(a + " " + x);
                a--;
                
            }
            b = b + 1;
        }
        for (int i = 0; i < 4; i++)
        {
            if (countUpDiagonal[i] > 1)
            {
                upDiagonal[i] = true;
            }
        }
    }

    public void checkWin()
    {
        check(Level4.instance.sizeOfLevel4);
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
            if (mainDownDiagonal[i])
            {
                Debug.Log("vi pham o duong cheo tren thu" + i);
                break;
            }
            if (mainUpDiagonal[i])
            {
                Debug.Log("vi pham o duong duoi cheo thu" + i);
                break;
            }
            if (downDiagonal[i])
            {
                Debug.Log("vi pham o duong cheo phu thu " + i);
                break;
            }
            if (upDiagonal[i])
            {
                Debug.Log("vi pham o duong cheo phu thu " + i +"phia tren");
                break;
            }
            if (!row[i])
            {
                

            }
            if (!column[i])
            {
               

            }
            if (!mainDownDiagonal[i])
            {
               
            }
            if (!mainUpDiagonal[i])
            {
                
            }
            if (!downDiagonal[i])
            {
              
            }
            if (!upDiagonal[i])
            {
                
            }
            
        }
        ResetValue();

    }
    private void ResetValue()
    {
        for (int i = 0; i < 4; i++)
        {
            countColumn[i] = 0;
            countRow[i] = 0;
            countMainDownDiagonal[i] = 0;
            countMainUpDiagonal[i] = 0;
            countDownDiagonal[i] = 0;
            countUpDiagonal[i] = 0;
        }
    }
}
