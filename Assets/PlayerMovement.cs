using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float rotationSpeed;

    Vector2 currentVector;
    Vector3 movermentVector;
    Rigidbody myRb;
    bool isPress = false;
    bool isJumpPress = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
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
            myRb.MovePosition(transform.position + movermentVector * Time.fixedDeltaTime);
            
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
        
        myRb.AddForce(movermentVector.x, 10f, movermentVector.y);
        Debug.Log("da nhay");
    }
    
}
