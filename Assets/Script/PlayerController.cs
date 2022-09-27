using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions.Tween;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Material w_brick;
    [SerializeField] Material b_brick;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject cloneOfPlayer;
    [SerializeField] TweenPlayer clone;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] Transform forward;
    [SerializeField] Transform back;
    [SerializeField] private float rollSpeed = 3;


    public bool isClone = false;
    private bool isMoving = false;



    // Start is called before the first frame update
    void Start()
    {

        transform.position = GenMap.instance.firtSpawPosition + new Vector3(0, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        getInputClonePlayer();
        getInput();

    }

    //private void FixedUpdate()
    //{
    //    //transform.position = Vector3.Normalize(transform.position);
    //    getInputClonePlayer();
    //    getInput();
    //}
   
    private void getInput()
    {
        if (isMoving) return;

        if (isClone)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Clone left");
                cloneBrickPlayer(left);
                //rollDirection(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Clone right");
                cloneBrickPlayer(right);
                //rollDirection(Vector3.right);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Clone back");
                cloneBrickPlayer(back);
                //rollDirection(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Clone forward");
                cloneBrickPlayer(forward);
                //rollDirection(Vector3.forward);
            }

        }
        else if(!isClone)
        {
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
        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        isMoving = false;
    }


    void getInputClonePlayer()
    {
        if (!isClone && Input.GetKeyDown(KeyCode.J))
        {
            isClone = true;
            clone.ForcePlayRuntime();
        }
        else if (isClone && Input.GetKeyDown(KeyCode.J))
        {
            isClone = false;
            clone.ForcePlayBackRuntime();
        }

    }

    void cloneBrickPlayer(Transform position)
    {
        GameObject clonePlayer = Instantiate(cloneOfPlayer, position.position, Quaternion.identity);      
    }
    
}
