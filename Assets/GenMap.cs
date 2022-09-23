using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMap : MonoBehaviour
{

    public class Cell
    {
        public bool isVisited = false;
        public bool[] status= new bool[4];
    }

    public Vector2 offset;
    List<Cell> board;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void createMaze()
    {
        board = new List<Cell>(); // tao list luu tru cac cell trong ma tran 2 chieu x*y;
        for(int i = 0; i < offset.x; i++)
        {
            for(int j= 0; j < offset.y; j++)
            {
                board.Add(new Cell()); // add cac cell vao trong list ;
            }
        }


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
            List<int> neighbor;

        }
    }
}
