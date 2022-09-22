using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
   

    [SerializeField] float rotationSpeed;
    [SerializeField] float speed;
    [SerializeField] GameObject player;


    Vector2 currentVector;
    public Vector3 movermentVector;
    Rigidbody myRb;

    public bool isPress = false;
    public bool isJumpPress = false;
    public bool canJump = false;
    public List<GameObject> clonePlayer;




    // Start is called before the first frame update

    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        movementControll();
        Rotation();
    }

    void movementControll()
    {
        if(isPress)
        {
            myRb.MovePosition(transform.position + movermentVector * Time.fixedDeltaTime * speed);
            
        }
    }
    void Rotation()
    {
        if (isPress)
        {
            Quaternion toRotation = Quaternion.LookRotation(movermentVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
        
    }
    void OnMove(InputValue movementVector2) //Get input form keyboard;
    {
        currentVector = movementVector2.Get<Vector2>();
        movermentVector = new Vector3(currentVector.x, 0f, currentVector.y);
        if (currentVector.x != 0 || currentVector.y != 0)
        {
            isPress = true;
        }
        else if (currentVector.x == 0 && currentVector.y == 0)
        {
            isPress = false;
        }
    }
    void checkJump()
    {
        //use on Mobie
    }
    void OnJump()
    {
        if (canJump)
        {
            myRb.AddForce(movermentVector.x, 400f, movermentVector.y);
        }

        //Debug.Log("da nhay");
    }
    void OnClone()
    {
        GameObject clone = Instantiate(player, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody>().isKinematic = true;
        clonePlayer.Add(clone);
        
    }
    private void OnCollisionExit(Collision collision)
    {
        //if (collision.transform.tag =="Platform")
        //{
            canJump = false;
        //}
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.tag == "Platform")
        //{
            canJump = true;
        //}
    }
    private void OnCollisionStay(Collision collision)
    {
        //if (collision.transform.tag == "Platform")
        //{
            canJump = true;
        //}
    }
    public void deleteClone()
    {
        for(int i = 0; i < clonePlayer.Count; i++)
        {
            Destroy(clonePlayer[i]);
            clonePlayer.Remove(clonePlayer[i]);
        }
    }
    public void enableClone()
    {
        for(int i = 0; i < clonePlayer.Count; i++)
        {
            clonePlayer[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
