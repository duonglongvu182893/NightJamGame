using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public static Level3 instance;

    public List<int> numberOfDisbaleBrick;
    public Vector2 sizeOfLevel3;
    public GameObject switchGate;
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
    }

    [System.Obsolete]
    public IEnumerator delay()
    {
        yield return new WaitForSeconds(0.3f);
        int positionOfSwitch;
        positionOfSwitch = Random.RandomRange(1, GenMap.instance.positionOfBrick.Count / 2);
        cloneSwitch(GenMap.instance.positionOfBrick[positionOfSwitch].transform.position);
    }
}
