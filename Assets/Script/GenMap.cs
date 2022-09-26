using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMap : MonoBehaviour
{
    public static GenMap instance;
    public class Cell
    {
        public bool isVisited = false;
        //public bool[] status= new bool[4];
        public bool targetBrick = false;

        public bool fallBrick = false;
    }
    [SerializeField] GameObject brick;
    [SerializeField] GameObject fallBrick;
    [SerializeField] GameObject targetBrick;


    //public Vector2 size;
    public Vector2 offset;
    public Vector3 firtSpawPosition;
    public List<Cell> board;
    public List<int> numberOfBrick;

    // Start is called before the first frame update
    
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    [System.Obsolete]
    void Start()
    {
        createList(level1.instance.sizeOfLevel1,1);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    public void genWay(Vector2 size)
    {
        firtSpawPosition = new Vector3(0, 0, 0);
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                Cell currenCell = board[Mathf.FloorToInt(i + j * size.x)];
                if (currenCell.isVisited && !currenCell.targetBrick)
                {
                    //int chosee = Random.RandomRange(0, 3);
                    if (currenCell.fallBrick)
                    {
                        GameObject newWay = Instantiate(fallBrick, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity);
                        numberOfBrick.Add(Mathf.FloorToInt(i + j * size.x));
                        
                    }
                    else
                    {
                        GameObject newWay = Instantiate(brick, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity);
                        numberOfBrick.Add(Mathf.FloorToInt(i + j * size.x));
                    }
                    
                }
                else if (currenCell.isVisited && currenCell.targetBrick)
                {
                    GameObject newWay = Instantiate(targetBrick, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity);
                    numberOfBrick.Add(Mathf.FloorToInt(i + j * size.x));
                }
            }
        }
        
    }

    [System.Obsolete]
    public void createList(Vector2 size,int level)
    {

        board = new List<Cell>(); // tao list luu tru cac cell trong ma tran 2 chieu x*y;
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell()); // add cac cell vao trong list ;
            }
        }
        if (level == 1)
        {
            level1.instance.selectLevel1(size);
        }
        
        
        board[board.Count - 1].targetBrick = true;

        createMaze(size);
        //createMaze(size);
    }

    [System.Obsolete]
    public void createMaze(Vector2 size)
    {
        //createList(size);
        //board = new List<Cell>(); // tao list luu tru cac cell trong ma tran 2 chieu x*y;
        //for(int i = 0; i < size.x; i++)
        //{
        //    for(int j= 0; j < size.y; j++)
        //    {
        //        board.Add(new Cell()); // add cac cell vao trong list ;
        //    }
        //}


        int currentCell = 0;
        //board[board.Count-1].targetBrick = true;
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
            List<int> neighbor= CheckNeighbors(currentCell,size);

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
    List<int> CheckNeighbors(int cell,Vector2 size) //tao list check neigbor tra ve mot neighbor
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
    
}
