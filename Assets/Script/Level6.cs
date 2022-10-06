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

    [SerializeField] UIElement dialog;
    [SerializeField] GameObject lv1;
    [SerializeField] GameObject lv3;
    [SerializeField] GameObject lv4;
    [SerializeField] GameObject lv6;
    [SerializeField] GameObject countText;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setUpLevel6();
    }
    
    private void OnEnable()
    {
        transform.position = new Vector3(0, 3, 0);
        //countText.SetActive(true);
        //lv1.SetActive(false);
        //lv3.SetActive(false);
        //lv4.SetActive(false);
        //lv6.SetActive(true);
    }

    //create map NxN
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

        
        for (int i = 0; i < 3; i++)
        {
            int a = Random.RandomRange(0, Mathf.FloorToInt(size.x));
            int b= Random.RandomRange(0, Mathf.FloorToInt(size.y));
            while (GenMap.instance.board[Mathf.FloorToInt(a + b * size.x)].choosenBrick&& (Mathf.FloorToInt(a + b * size.x)==0))
            {
                a = Random.RandomRange(0, Mathf.FloorToInt(size.x));
                b = Random.RandomRange(0, Mathf.FloorToInt(size.y));
            }
            
            GenMap.instance.board[Mathf.FloorToInt(a+ b * size.x)].choosenBrick = true;
            GameObject padClone = Instantiate(pad, new Vector3(a * 3, 1.5f, -b * 3), Quaternion.identity);
            Debug.Log(a + b * size.x);
        }

    }

    //check Win level6
    public void setUpLevel6()
    {
        for(int i = 0; i < sizeOfLevel6.x; i++)
        {
            for(int j = 0; j < sizeOfLevel6.x; j++)
            {
                if(GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].istouch&& GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].choosenBrick)
                {
                    Debug.Log("dung");
                    //GenMap.instance.resetTouch();
                }
                else if(GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].istouch && !GenMap.instance.board[Mathf.FloorToInt(i + j * sizeOfLevel6.x)].choosenBrick)
                {
                    Debug.Log("sai");
                    GenMap.instance.resetTouch();
                }
            }
        }
    }
    public void beginLevel6()
    {
        runlevel6 = true;
        countText.SetActive(true);
    }
    public void resetLevel6()
    {
        StartCoroutine(PlayerController.instance.destroyClone());
        GenMap.instance.resetTouch();
        PlayerWhenStart.instance.numberOfClone = 3;
    }

}
