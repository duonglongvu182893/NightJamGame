using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NQueen : MonoBehaviour
{
    public bool[] c0;
    public bool[] c1;
    public bool[] c2;
    public bool[] c3;


    public bool[] ha0;
    public bool[] ha1;
    public bool[] ha2;
    public bool[] ha3;
    public bool[] ha4;

    public bool[] hb0;
    public bool[] hb1;
    public bool[] hb2;
    public bool[] hb3;
    public bool[] hb4;



    // Start is called before the first frame update
    void Start()
    {
        c0 = new bool[6];
        c1 = new bool[6];
        c2 = new bool[6];
        c3 = new bool[6];

        ha0 = new bool[6];
        ha1 = new bool[6];
        ha2 = new bool[6];
        ha3 = new bool[6];
        ha4 = new bool[6];

        hb0 = new bool[6];
        hb1 = new bool[6];
        hb2 = new bool[6];
        hb3 = new bool[6];
        hb4 = new bool[6];

        for(int i=0; i < 6; i++)
        {
            c0[i] = false;
            c1[i] = false;
            c2[i] = false;
            c3[i] = false;
            if (i == 5)
            {
                c0[i] = true;
                c1[i] = true;
                c2[i] = true;
                c3[i] = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //duong cheo chinh
        //ha0
        ha0[0] = c0[2];
        ha0[1] = c1[3];
        //ha1
        ha1[0] = c0[1];
        ha1[1] = c1[2];
        ha1[2] = c2[3];
        //ha2
        ha2[0] = c0[0];
        ha2[1] = c1[1];
        ha2[2] = c2[2];
        ha2[3] = c2[3];
        //ha3
        ha3[0] = c1[0];
        ha3[1] = c2[1];
        ha3[2] = c3[2];
        //ha4
        ha4[0] = c2[0];
        ha4[1] = c3[1];

        //duong cheo phu
        //hb0
        hb0[0] = c3[2];
        hb0[1] = c2[3];
        //hb1
        hb1[0] = c3[1];
        hb1[1] = c2[2];
        hb1[2] = c1[3];
        //hb2
        hb2[0] = c3[0];
        hb2[1] = c2[1];
        hb2[2] = c1[2];
        hb2[3] = c0[3];
        //hb3
        hb3[0] = c2[0];
        hb3[1] = c1[1];
        hb3[2] = c0[2];
        //hb4
        hb4[0] = c1[0];
        hb4[1] = c0[1];

        
    }
    public void checkWin()
    {
        if (c0[5] && c1[5] && c2[5] && c3[5])
        {
            Debug.Log("khong vi pham");

        }
        else
        {
            Debug.Log("vi pham");
        }
    }
    public void check()
    {
        //check duong thang
        //c0
        int countc0 = 0;
        
        for(int i = 0; i < 4; i++)
        {
            if (c0[i] == true)
            {
                countc0 += 1;
            }
        }
        if (countc0 > 1)
        {
            c0[5] = false;
            
        }
        if (countc0 <= 1)
        {
            c0[5] = true;
            
        }
        //c1
        int countc1 = 0;

        for (int i = 0; i < 4; i++)
        {
            if (c1[i] == true)
            {
                countc1 += 1;
            }
        }
        if (countc1 > 1)
        {
            c1[5] = false;

        }
        if (countc0 <= 1)
        {
            c1[5] = true;

        }
        //c2
        int countc2 = 0;

        for (int i = 0; i < 4; i++)
        {
            if (c2[i] == true)
            {
                countc2 += 1;
            }
        }
        if (countc2 > 1)
        {
            c2[5] = false;

        }
        if (countc2 <= 1)
        {
            c2[5] = true;

        }
        //c3
        int countc3 = 0;

        for (int i = 0; i < 4; i++)
        {
            if (c3[i] == true)
            {
                countc3 += 1;
            }
        }
        if (countc3 > 1)
        {
            c3[5] = false;

        }
        if (countc0 <= 1)
        {
            c3[5] = true;

        }
        ////c4
        //int countc4 = 0;

        //for (int i = 0; i < 4; i++)
        //{
        //    if (c4[i] == true)
        //    {
        //        countc3 += 1;
        //    }
        //}
        //if (countc4 > 1)
        //{
        //    c4[5] = false;

        //}
        //if (countc0 <= 1)
        //{
        //    c4[5] = true;

        //}


    }
    public void clickc0(int i)
    {
        c0[i] = true;
       
    }
    public void clickc1(int i)
    {
        c1[i] = true;
       
    }
    public void clickc2(int i)
    {
        c2[i] = true;
    }
    public void clickc3(int i)
    {
        c3[i] = true;
    }
}
