using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EazyEngine.UI;
using TMPro;

public class Level6 : MonoBehaviour
{
    public static Level6 instance;

    public GameObject Player;
    public Vector2 sizeOfLevel6;
    public TextMeshProUGUI text;
    public GameObject pad;
    public bool runlevel6 = false;
    public GameObject win;
    public int count = 0;


    [SerializeField] UIElement dialog;
    [SerializeField] UIElement startLEvel6;
    [SerializeField] GameObject lv1;
    [SerializeField] GameObject lv3;
    [SerializeField] GameObject lv4;
    [SerializeField] GameObject lv6;
    [SerializeField] GameObject countText;

    public int[] number;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 3, 0);
        
        lv1.SetActive(false);
        lv3.SetActive(false);
        lv4.SetActive(false);
        lv6.SetActive(true);
        dialog.show();
    }
    
    [System.Obsolete]
    private void FixedUpdate()
    {
        if (PlayerWhenStart.instance.numberOfClone == 0)
        {
            for (int i = 0; i < sizeOfLevel6.x; i++)
            {
                for (int j = 0; j < sizeOfLevel6.x; j++)
                {
                    if (GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].istouch && GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].choosenBrick)
                    {
                        count++;
                        Debug.Log("dung");

                    }
                    else if (GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].istouch && !GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].choosenBrick)
                    {

                        Debug.Log("sai");

                    }
                }
            }
            if (count == 3)
            {
                win.SetActive(true);
            }
            else
            {
                GenMap.instance.DestroyMap();
                GenMap.instance.DestroyTool();
                PlayerWhenStart.instance.setLevel(PlayerWhenStart.instance.level);
                PlayerController.instance.isUsingUI = true;
                startLEvel6.show();
                Player.transform.GetComponent<Rigidbody>().isKinematic = true;
                Player.transform.position = new Vector3(0, 3, 0);
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
                resetLevel6();
                Debug.Log("so dem la" + count);
                count = 0;
            }
        }
    }

    private void OnEnable()
    {
        count = 0;
        lv3.SetActive(false);
        lv1.SetActive(false);
        lv4.SetActive(false);
        lv6.SetActive(true);
        dialog.show();
        Player.transform.position = new Vector3(0, 3, 0);
        StartCoroutine(PlayerController.instance.delayFX());
    }

    [System.Obsolete]
    public void createMatrixNxN(Vector2 size)
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GenMap.instance.board[Mathf.FloorToInt(i + j * size.x)].isVisited = true;

            }
        }

        for(int i = 0; i < 3; i++)
        {
            Vector3 position = chooseBrick(size);
            GameObject padClone = Instantiate(pad, position, Quaternion.identity);
        }
        
  
    }

    [System.Obsolete]
    public Vector3 chooseBrick(Vector2 size)
    {

        int a = Random.RandomRange(0, Mathf.FloorToInt(size.x));
        
        int b = Random.RandomRange(0, Mathf.FloorToInt(size.y));
       
        if (Mathf.FloorToInt(a + b * size.x) == 0)
        {
            return chooseBrick(size);

        }
        else if(Mathf.FloorToInt(a + b * size.x) == 24)
        {
            return chooseBrick(size);
        }
        else
        {
            GenMap.instance.board[Mathf.FloorToInt(a + b * size.x)].choosenBrick = true;
            Debug.Log("so duoc chon la "+ Mathf.FloorToInt(a + b * size.x));
           
            return new Vector3(a * 3, 1.5f, -b * 3);

          
        }

    }

    //check Win level6
    [System.Obsolete]
    public void setUpLevel6()
    {
        //count = 0;
        
    }

    public void beginLevel6()
    {
        runlevel6 = true;
        countText.SetActive(true);
        startLEvel6.close();
    }
    public void resetLevel6()
    {
        StartCoroutine(PlayerController.instance.destroyClone());
        GenMap.instance.resetTouch();
        PlayerWhenStart.instance.numberOfClone = 3;
    }

    //IEnumerator delayLevel6()
    //{

    //}
}
