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


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }


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

    //private void FixedUpdate()
    //{
    //    transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
    //}

    private void getInput()
    {
        if (isMoving) return;

        if (isClone && (PlayerWhenStart.instance.numberOfClone > 0)) 
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Clone left");
                cloneBrickPlayer(left);
                PlayerWhenStart.instance.numberOfClone--;
                
                //rollDirection(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Clone right");
                cloneBrickPlayer(right);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.right);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Clone back");
                cloneBrickPlayer(back);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.W))
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
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
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
        //if (PlayerWhenStart.instance.level == 4)
        //{
            GameObject clonePlayer = Instantiate(cloneOfPlayer, position.position, Quaternion.identity);
            cloneBrick.Add(clonePlayer);
        //}
        //else if (PlayerWhenStart.instance.level != 4)
        //{
        //    GameObject clonePlayer = Instantiate(cloneOfPlayerlevel5, position.position, Quaternion.identity);
        //    cloneBrick.Add(clonePlayer);
        //}
        
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
        
    }

    void CheckSwipe()
    {
        if (isMoving) return;

        if (isClone && (PlayerWhenStart.instance.numberOfClone > 0))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Clone left");
                cloneBrickPlayer(left);
                PlayerWhenStart.instance.numberOfClone--;

                //rollDirection(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Clone right");
                cloneBrickPlayer(right);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.right);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Clone back");
                cloneBrickPlayer(back);
                PlayerWhenStart.instance.numberOfClone--;
                //rollDirection(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.W))
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
