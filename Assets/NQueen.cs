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



    // Start is called before the first frame update
    void Start()
    {
        c0 = new bool[4];
        c1 = new bool[4];
        c2 = new bool[4];
        c3 = new bool[4];
    }

    // Update is called once per frame
    void Update()
    {
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
        //ha


    }
    void check()
    {

    }
    public void clickc0(int i)
    {
        c0[i] = true;
        ha2[0] = true;
        ha1[0] = true;
        ha0[0] = true;
    }
    public void clickc1(int i)
    {
        c1[i] = true;
        ha3[0] = true
        ha2[1] = true;
        ha1[1] = true;
        ha0[1] = true;
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
