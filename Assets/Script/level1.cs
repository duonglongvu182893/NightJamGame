using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityExtensions.Tween;
using EazyEngine.UI;

public class level1 : MonoBehaviour
{
    public GameObject player;
    public GameObject playerFx;
    public static level1 instance;
    public Vector2 sizeOfLevel1;
    public TextMeshProUGUI textlv1;

    //[SerializeField] TweenPlayer level1Dialog;
    //[SerializeField] GameObject level1Di;
    [SerializeField] UIElement dialog;
    [SerializeField] GameObject lv1;
    [SerializeField] GameObject lv3;
    [SerializeField] GameObject lv4;
    [SerializeField] GameObject lv6;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    [System.Obsolete]

    void Start()

    {
        lv1.SetActive(true);
        lv3.SetActive(false);
        lv4.SetActive(false);
        lv6.SetActive(false);
        dialog.show();
      
        player.transform.position = new Vector3(0, 3, 0);
        StartCoroutine(delayFX());
        StartCoroutine(delay());

        textlv1.text = "Swipe your screne to move ";
        
        
    }

    [System.Obsolete]
    public void selectLevel1(Vector2 size)
    {
        //GenMap.instance.createList(size);
        for(int i = 0; i < GenMap.instance.board.Count; i++)
        {
            if (i % 2 == 0)
            {
                GenMap.instance.board[i].fallBrick = true;
            }
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        winCheck.instance.checkWin();
    }
    IEnumerator delayFX()
    {
        playerFx.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerFx.SetActive(false);
    }
}
