using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Material w_brick;
    [SerializeField] Material b_brick;
    [SerializeField] GameObject Player;
    [SerializeField] private float rollSpeed = 3;

    private bool isMoving = false;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = GenMap.instance.firtSpawPosition + new Vector3(-1.5f, 1.5f, 1.5f);
  
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void getInput()
    {
        if (isMoving) return;
            
        if (Input.GetKeyDown(KeyCode.A))
        {
            rollDirection(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rollDirection(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rollDirection(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rollDirection(Vector3.forward);
        }
    }

    void rollDirection(Vector3 dir)
    {
        var anchor = transform.position + (Vector3.down + dir) * 1.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
    }
        


    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;
        for(int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        isMoving = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "W_Brick")
        {
            Player.GetComponent<MeshRenderer>().material = b_brick;
        }
        if (collision.transform.tag == "Black_Brick")
        {
            Player.GetComponent<MeshRenderer>().material = w_brick;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "W_Brick")
        {
            Player.GetComponent<MeshRenderer>().material = b_brick;
        }
        if (collision.transform.tag == "Black_Brick")
        {
            Player.GetComponent<MeshRenderer>().material = w_brick;
        }
    }
}
