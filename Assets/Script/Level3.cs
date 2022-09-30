using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public static Level3 instance;
    public GameObject player;
    public List<int> numberOfDisbaleBrick;
    public Vector2 sizeOfLevel3;
    public GameObject switchGate;
    [SerializeField] GameObject brick;
    GameObject brickGate;
    GameObject brickGate1;
    GameObject brickGate2;
    //List<GameObject> brickGate = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(0, 3, 0);
        brickGate =  Instantiate(brick, new Vector3(2 * 3, 0, -5 * 3), Quaternion.identity);
        GenMap.instance.positionOfBrick.Add(brickGate);
        brickGate1 = Instantiate(brick, new Vector3(2 * 3, 0, -4 * 3), Quaternion.identity);
        GenMap.instance.positionOfBrick.Add(brickGate1);
        brickGate2 = Instantiate(brick, new Vector3(3 * 3, 0, -4 * 3), Quaternion.identity);
        GenMap.instance.positionOfBrick.Add(brickGate2);
        brickGate.SetActive(false);
        brickGate1.SetActive(false);
        brickGate2.SetActive(false);

    }

    private void OnEnable()
    {
        player.transform.position = new Vector3(0, 3, 0);
        brickGate = Instantiate(brick, new Vector3(2 * 3, 0, -5 * 3), Quaternion.identity);
        GenMap.instance.positionOfBrick.Add(brickGate);
        brickGate1 = Instantiate(brick, new Vector3(2 * 3, 0, -4 * 3), Quaternion.identity);
        GenMap.instance.positionOfBrick.Add(brickGate1);
        brickGate2 = Instantiate(brick, new Vector3(3 * 3, 0, -4 * 3), Quaternion.identity);
        GenMap.instance.positionOfBrick.Add(brickGate2);
        brickGate.SetActive(false);
        brickGate1.SetActive(false);
        brickGate2.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectLevel3(Vector3 size)
    {
        numberOfDisbaleBrick.Add(22);
        numberOfDisbaleBrick.Add(18);
        numberOfDisbaleBrick.Add(19);
        disableBrick();

    }
    void disableBrick()
    {

        for (int i = 0; i < numberOfDisbaleBrick.Count; i++)
        {
            GenMap.instance.board[(numberOfDisbaleBrick[i])].disableBrick = true;
            Debug.Log((numberOfDisbaleBrick[i]));
        }
        

    }


    void cloneSwitch(Vector3 position)
    {
        GameObject switchClone = Instantiate(switchGate, new Vector3(position.x, 1.5f, position.z), Quaternion.identity);
        GenMap.instance.tool.Add(switchClone);

    }

    [System.Obsolete]
    public IEnumerator delay()
    {
        yield return new WaitForSeconds(0.3f);
        int positionOfSwitch;
        positionOfSwitch = Random.RandomRange(1, GenMap.instance.positionOfBrick.Count / 2);
        cloneSwitch(GenMap.instance.positionOfBrick[positionOfSwitch].transform.position);
    }
    public void setActiveBrick(int a)
    {
        if (a == 0)
        {
            brickGate.SetActive(false);
            brickGate1.SetActive(false);
            brickGate2.SetActive(false);
        }
        if (a == 1)
        {
            brickGate.SetActive(true);
            brickGate1.SetActive(true);
            brickGate2.SetActive(true);
        }
    }
}
