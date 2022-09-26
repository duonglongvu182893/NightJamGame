using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public static Level2 instance;

    public List<int> numberOfDisbaleBrick ;
    public Vector2 sizeOfLevel2;
    public GameObject switchGate;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    [System.Obsolete]
    private void OnEnable()
    {

        StartCoroutine(delay());
    }
    // Update is called once per frame
    void Update()
    {

    }

    [System.Obsolete]
    public void selectLevel2(Vector2 size)
    {
        //numberOfDisbaleBrick.Add(Mathf.FloorToInt((size.x - 1) + size.y * sizeOfLevel2.x));
        //numberOfDisbaleBrick.Add(Mathf.FloorToInt((size.x - 1) + (size.y - 1) * sizeOfLevel2.x));
        //numberOfDisbaleBrick.Add(Mathf.FloorToInt(size.x + (size.y - 1) * sizeOfLevel2.x));
        numberOfDisbaleBrick.Add(22);
        numberOfDisbaleBrick.Add(18);
        numberOfDisbaleBrick.Add(19);
        //int positionOfSwitch = Random.RandomRange(0, GenMap.instance.positionOfBrick.Count);
        //cloneSwitch(GenMap.instance.positionOfBrick[positionOfSwitch].position);

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
    }

    [System.Obsolete]
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.3f);
        int positionOfSwitch;
        positionOfSwitch = Random.RandomRange(1, GenMap.instance.positionOfBrick.Count/2);
        cloneSwitch(GenMap.instance.positionOfBrick[positionOfSwitch].transform.position);
    }
}

    