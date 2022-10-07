using System.Collections;
using System.Collections.Generic;
using UnityExtensions.Tween;
using EazyEngine.UI;

using UnityEngine;

public class GenMap : MonoBehaviour
{
    public static GenMap instance;
    public class Cell
    {
        public bool isVisited = false;

        public bool targetBrick = false;

        public bool fallBrick = false;

        public bool disableBrick = false;

        public bool istouch = false;

        public bool choosenBrick = false;
    }
    [SerializeField] GameObject brick;
    [SerializeField] GameObject fallBrick;
    [SerializeField] GameObject targetBrick;
    [SerializeField] GameObject saveTarget;
    [SerializeField] GameObject win;


    //public bool[] isTouch = new bool[16];
    public Vector2 offset;
    public Transform firtSpawPosition;
    public List<Cell> board;
    public List<int> numberOfBrick;
    public List<GameObject> positionOfBrick;
    public List<GameObject> brickDisable;
    public List<GameObject> tool;
    public List<GameObject> choosenBrick;
    public List<int> numberOfDisbaleBrick;
    

    //private TweenPlayer abc;
    private void Awake()
    {
        //instance = this;
        //if (instance != null) { }

        ////đã có instance -> hủy object mới tạo
        //else
        //{
            instance = this;
            //DontDestroyOnLoad(gameObject);
        //}
    }

    [System.Obsolete]
    void Start()
    {
        //chosenBrick();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    public void genWay(Vector2 size)
    {
        //firtSpawPosition;
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell currenCell = board[Mathf.FloorToInt(i + j * size.x)];
                if (currenCell.isVisited && !currenCell.targetBrick)
                {
                    if (currenCell.fallBrick)
                    {
                        GameObject newWay = Instantiate(fallBrick, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity);
                        numberOfBrick.Add(Mathf.FloorToInt(i + j * size.x));
                        positionOfBrick.Add(newWay);
                        if (currenCell.disableBrick)
                        {
                            newWay.SetActive(false);
                            brickDisable.Add(newWay);

                        }

                    }
                    //else if (currenCell.choosenBrick)
                    //{

                    //}
                    else
                    {
                        GameObject newWay = Instantiate(brick, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity);
                        numberOfBrick.Add(Mathf.FloorToInt(i + j * size.x));
                        positionOfBrick.Add(newWay);
                        if (currenCell.disableBrick)
                        {
                            newWay.SetActive(false);
                            brickDisable.Add(newWay);
                            positionOfBrick.Add(newWay);
                        }
                        if (currenCell.choosenBrick)
                        {
                            choosenBrick.Add(newWay);
                        }

                    }

                }
                else if (currenCell.isVisited && currenCell.targetBrick)
                {
                    if (PlayerWhenStart.instance.level < 4)
                    {
                        GameObject newWay = Instantiate(targetBrick, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity);
                        numberOfBrick.Add(Mathf.FloorToInt(i + j * size.x));
                        saveTarget = newWay;
                    }
                    else
                    {
                        GameObject newWay = Instantiate( brick, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity);
                        numberOfBrick.Add(Mathf.FloorToInt(i + j * size.x));
                        saveTarget = newWay;

                    }
                    
                }

            }
        }
        

    }

    [System.Obsolete]
    public void createList(Vector2 size, int level)
    {

        board = new List<Cell>(); // tao list luu tru cac cell trong ma tran 2 chieu x*y;
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell()); // add cac cell vao trong list ;
            }
        }
        switch (level)
        {
            case 1:
                {
                    level1.instance.selectLevel1(size);
                    PlayerWhenStart.instance.level = 1;
                    break;
                }
            case 2:
                {
                    Level2.instance.selectLevel2(size);
                    StartCoroutine(Level2.instance.delay());
                    PlayerWhenStart.instance.level = 2;
                    break;
                }

            case 3:
                {
                    Level3.instance.selectLevel3(size);
                    StartCoroutine(Level3.instance.delay());
                    PlayerWhenStart.instance.level = 3;
                    break;
                }
            case 4:
                {
                    //
                    PlayerWhenStart.instance.level = 4;
                    Level4.instance.createMatrixNxN(size);
                    //Level4.instance.check(size);

                    break;
                }
            case 5:
                {
                    PlayerWhenStart.instance.level = 5;
                    Level5.instance.createMatrixNxN(size);
                    break;
                }
            case 6:
                {
                    Level6.instance.createMatrixNxN(size);

                    break;
                }
            case 7:
                {
                    //
                    break;
                }
        }

        board[board.Count - 1].targetBrick = true;
       
        createMaze(size);


        //

        //for(int i = 0; i < board.Count; i++)
        //{
        //    if (!board[i].choosenBrick)
        //    {
        //        choosenBrick.Add()
        //    }
        //}
    }

    [System.Obsolete]
    public void createMaze(Vector2 size)
    {
        int currentCell = 0;
        Stack<int> path = new Stack<int>(); //khoi tao stack rong;
        int k = 0;

        while (k < 1000)
        {
            k++;
            board[currentCell].isVisited = true;
            if (currentCell == board.Count - 1)
            {
                break;
            }
            List<int> neighbor = CheckNeighbors(currentCell, size);

            if (neighbor.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {

                path.Push(currentCell);
                int newCell = neighbor[Random.RandomRange(0, neighbor.Count)];
                currentCell = newCell;

            }
        }
        genWay(size);

    }
    public List<int> CheckNeighbors(int cell, Vector2 size) //tao list check neigbor tra ve mot neighbor
    {
        List<int> neighbors = new List<int>(); //list kieu int  chua neighborsx
                                               // up neighbor



        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].isVisited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
            //Debug.Log(cell - size.x);
        }
        //down nighbor
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].isVisited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
            //Debug.Log(cell + size.x);
        }
        if (((cell + 1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].isVisited))
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
            //Debug.Log(cell + 1);
        }
        if ((cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].isVisited))
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
            //Debug.Log(cell - 1);
        }
        return neighbors;

    }

    public void setTouch(int i, int j, Vector2 size)
    {
        board[Mathf.FloorToInt(i + j * size.x)].istouch = true;

        Debug.Log("o duoc chon la "+ Mathf.FloorToInt(i + j * size.x));

        //if (board[Mathf.FloorToInt(i + j * size.x)].choosenBrick)
        //{
        //    Debug.Log("LEvel6 check");
        //}
    }
    public void resetTouch()
    {
        for (int i = 0; i < board.Count; i++)
        {
            board[i].istouch = false;
        }
    }

    public IEnumerator delayEnable()
    {
        for (int i = 0; i < brickDisable.Count; i++)
        {
            brickDisable[i].SetActive(true);
            brickDisable[i].GetComponent<TweenPlayer>().ForcePlayRuntime();
            yield return new WaitForSeconds(0.2f);
        }
    }
    public IEnumerator delayDiable()
    {
        for (int i = 0; i < brickDisable.Count; i++)
        {
            brickDisable[i].GetComponent<TweenPlayer>().ForcePlayBackRuntime();
            yield return new WaitForSeconds(0.2f);
            brickDisable[i].SetActive(false);

        }
        //brickDisable.Clear();
    }
    public IEnumerator delayMap()
    {
        StartCoroutine(PlayerController.instance.destroyClone());
        for (int i = 0; i < positionOfBrick.Count; i++)
        {
            positionOfBrick[i].GetComponent<TweenPlayer>().ForcePlayBackRuntime();
            yield return new WaitForSeconds(0.1f);
            positionOfBrick[i].SetActive(false);

        }

        positionOfBrick.Clear();


    }
    public void DestroyMap()
    {
        for (int i = 0; i < positionOfBrick.Count; i++)
        {

                Destroy(positionOfBrick[i]);
                Destroy(saveTarget);
            
            
        }
        for(int i = 0; i < brickDisable.Count; i++)
        {
            Destroy(brickDisable[i]);
        }
        brickDisable.Clear();
        positionOfBrick.Clear();
    }
    public void DestroyTool()
    {
        for (int i = 0; i < tool.Count; i++)
        {

            Destroy(tool[i]);
            
        }
        tool.Clear();
    }

    

}
