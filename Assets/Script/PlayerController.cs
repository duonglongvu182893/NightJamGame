using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions.Tween;

public class PlayerController : MonoBehaviour
{


    public static PlayerController instance;


    [SerializeField] Material w_brick;
    [SerializeField] Material b_brick;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject cloneOfPlayer;
    [SerializeField] GameObject cloneOfPlayerlevel5;
    [SerializeField] TweenPlayer clone;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] Transform forward;
    [SerializeField] Transform back;
    [SerializeField] private float rollSpeed = 3;


    public Swipe swipeController;
    public List<GameObject> cloneBrick = new List<GameObject>();


    public bool isClone = false;
    public bool isMoving = false;

    public bool isBlockOnTheLeft = false;
    public bool isBlockOnTheRight = false;
    public bool isBlockFoward = false;
    public bool isBlockBack = false;

    private void Awake()
    {
        //if (instance == null)
        //{
            instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else if (instance != this)
        //{
        //    Destroy(gameObject);

        //}
      


    }
    protected void OnDestroy()
    {
        //Nhớ giải phóng vì đây là static
        if (instance == this)
        {
            instance = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        //transform.position = GenMap.instance.firtSpawPosition.position + new Vector3(0, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        getInputClonePlayer();
        getInput();
        CheckSwipe();

        
    }

    private void FixedUpdate()
    {
        
    }

    private void getInput()
    {
        if (isMoving) return;

        if (isClone && (PlayerWhenStart.instance.numberOfClone > 0)) 
        {
            if (Input.GetKeyDown(KeyCode.A) && !isBlockOnTheLeft) 
            {
                Debug.Log("Clone left");
                cloneBrickPlayer(left);
                PlayerWhenStart.instance.numberOfClone--;
                
                //rollDirection(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.D)&& !isBlockOnTheRight)
            {
                Debug.Log("Clone right");
                cloneBrickPlayer(right);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.right);
            }
            if (Input.GetKeyDown(KeyCode.S) && !isBlockBack) 
            {
                Debug.Log("Clone back");
                cloneBrickPlayer(back);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.W) && !isBlockFoward)
            {
                Debug.Log("Clone forward");
                cloneBrickPlayer(forward);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.forward);
            }

        }
        if (isClone && (PlayerWhenStart.instance.numberOfClone <= 0))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Can't Clone left");
                
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Can't Clone right");
                
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Can't Clone back");
                
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Can't Clone forward");
                
            }

        }
        else if(!isClone)
        {
            if (Input.GetKeyDown(KeyCode.A) && !isBlockOnTheLeft)
            {
                rollDirection(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.D) && !isBlockOnTheRight)
            {
                rollDirection(Vector3.right);
            }
            if (Input.GetKeyDown(KeyCode.S) && !isBlockBack)
            {
                rollDirection(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.W) && !isBlockFoward)
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
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        isMoving = false;
        //Debug.Log(Mathf.Abs(transform.rotation.x) + ", " + Mathf.Abs(transform.rotation.y) + ", " + Mathf.Abs(transform.rotation.z));
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
    public void getPutButton()
    {
        if (!isClone)
        {
            isClone = true;
            clone.ForcePlayRuntime();
        }
        else if (isClone)
        {
            isClone = false;
            clone.ForcePlayBackRuntime();
        }
    }

    void cloneBrickPlayer(Transform position)
    {
        
            GameObject clonePlayer = Instantiate(cloneOfPlayer, position.position, Quaternion.identity);
            cloneBrick.Add(clonePlayer);
       
    }
    public void deleteClone()
    {
        for (int i = 0; i < cloneBrick.Count; i++)
        {
            Destroy(cloneBrick[i]);
        }
        cloneBrick.Clear();
    }
    public IEnumerator destroyClone()
    {
        for(int i = 0; i < cloneBrick.Count; i++)
        {
            cloneBrick[i].GetComponent<TweenPlayer>().ForcePlayBackRuntime();
            yield return new WaitForSeconds(0.4f);
             Destroy(cloneBrick[i]);
        }
        cloneBrick.Clear();
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Finish")
        {
            for (int i = 0; i < cloneBrick.Count; i++)
            {
                cloneBrick[i].GetComponent<TweenPlayer>().ForcePlayBackRuntime();
                //yield return new WaitForSeconds(0.4f);
                Destroy(cloneBrick[i]);
            }
        }
        if (other.transform.tag == "Clone")
        {
            Debug.Log("va cham tai " + other.transform.position);


            if (other.transform.position.x == transform.position.x)
            {
                Debug.Log("khong nhan input o phia " + "(0, 0, " + other.transform.position.z +")");
            }
            if (other.transform.position.z == transform.position.z)
            {
                Debug.Log("khong nhan input o phia " + other.transform.position.x  +" ,0, 0)" );
            }
        }
        if(other.transform.tag == "DeadZone")
        {
            //UIController.instance.reload();
            GenMap.instance.DestroyMap();
            GenMap.instance.DestroyTool();
            StartCoroutine(PlayerController.instance.destroyClone());
            PlayerWhenStart.instance.setLevel(PlayerWhenStart.instance.level);
            Player.transform.position = new Vector3(0, 3, 0);
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (PlayerWhenStart.instance.level != 4 && PlayerWhenStart.instance.level != 5)
            {
                winCheck.instance.checkWin();
            }
        }
        
    }

    void CheckSwipe()
    {
        if (isMoving) return;

        if (isClone && (PlayerWhenStart.instance.numberOfClone > 0))
        {
            if (swipeController.SwipeLeft)
            {
                Debug.Log("Clone left");
                cloneBrickPlayer(left);
                PlayerWhenStart.instance.numberOfClone--;

                //rollDirection(Vector3.left);
            }
            if (swipeController.SwipeRight)
            {
                Debug.Log("Clone right");
                cloneBrickPlayer(right);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.right);
            }
            if (swipeController.SwipeDown)
            {
                Debug.Log("Clone back");
                cloneBrickPlayer(back);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.back);
            }
            if (swipeController.SwipeUp)
            {
                Debug.Log("Clone forward");
                cloneBrickPlayer(forward);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.forward);
            }

        }
        if (isClone && (PlayerWhenStart.instance.numberOfClone <= 0))
        {
            if (swipeController.SwipeLeft)
            {
                Debug.Log("Can't Clone left");

            }
            if (swipeController.SwipeRight)
            {
                Debug.Log("Can't Clone right");

            }
            if (swipeController.SwipeDown)
            {
                Debug.Log("Can't Clone back");

            }
            if (swipeController.SwipeUp)
            {
                Debug.Log("Can't Clone forward");

            }

        }
        else if (!isClone)
        {
            if (swipeController.SwipeLeft)
            {
                rollDirection(Vector3.left);
            }
            if (swipeController.SwipeRight)
            {
                rollDirection(Vector3.right);
            }
            if (swipeController.SwipeDown)
            {
                rollDirection(Vector3.back);
            }
            if (swipeController.SwipeUp)
            {
                rollDirection(Vector3.forward);
            }
        }
        

    }
    
}
