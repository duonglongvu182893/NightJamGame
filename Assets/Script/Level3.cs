using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EazyEngine.UI;

public class Level3 : MonoBehaviour
{
    public static Level3 instance;
    public GameObject player;
    public List<int> numberOfDisbaleBrick;
    public Vector2 sizeOfLevel3;
    public GameObject switchGate;
    [SerializeField] GameObject brick;
    [SerializeField] UIElement dialog;
    [SerializeField] GameObject lv3;
    [SerializeField] GameObject lv1;
    [SerializeField] GameObject lv4;
    [SerializeField] TextMeshProUGUI textlv3;
   
    private void Awake()
    {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {



        player.transform.GetComponent<Rigidbody>().isKinematic = true;
        player.transform.position = new Vector3(0, 3, 0);
        

    }

    private void OnEnable()
    {
        lv3.SetActive(true);
        lv1.SetActive(false);
        lv4.SetActive(false);
        dialog.show();
        
        textlv3.text = " Combine with Put button to put another cube in the right position";
        player.transform.position = new Vector3(0, 3, 0);
       
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
        positionOfSwitch = Random.RandomRange(1, GenMap.instance.positionOfBrick.Count / 3);
        cloneSwitch(GenMap.instance.positionOfBrick[positionOfSwitch].transform.position);
    }
   
}
