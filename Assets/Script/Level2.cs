using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2 : MonoBehaviour
{
    public static Level2 instance;

    
    public GameObject player;
    public List<int> numberOfDisbaleBrick ;
    public Vector2 sizeOfLevel2;
    public GameObject switchGate;
    public TextMeshProUGUI textlv2;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        player.transform.position = new Vector3(0, 3, 0); 
        StartCoroutine(delayWin());
    }
    private void OnEnable()
    {
        textlv2.text = "Swipe your screne to move, use tool on the Way";
        player.transform.position = new Vector3(0, 3, 0);
        StartCoroutine(PlayerController.instance.delayFX());
        StartCoroutine(delayWin());
       
    }
    
    [System.Obsolete]
    public void selectLevel2(Vector2 size)
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
        
        positionOfSwitch = Random.RandomRange(1, GenMap.instance.positionOfBrick.Count/3);
        cloneSwitch(GenMap.instance.positionOfBrick[positionOfSwitch].transform.position);
    }
    IEnumerator delayWin()
    {
        yield return new WaitForSeconds(1f);
        winCheck.instance.checkWin();
    }
    
}

    
