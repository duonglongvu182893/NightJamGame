using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions.Tween;
using UnityEngine.UI;
using EazyEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] UIElement startUI;
    [SerializeField] UIElement sellectionButton;
    [SerializeField] UIElement guildButton;
    [SerializeField] UIElement loadTrans;
    [SerializeField] UIElement reloadTrans;
    [SerializeField] UIElement guideDialog;

    [SerializeField] TextMeshProUGUI level;

    [SerializeField] TweenPlayer testTing;
    [SerializeField] GameObject Player;

    //[SerializeField] GameObject Camera;
 
    [SerializeField] Button Resset;
    [SerializeField] Button Guild;
    [SerializeField] Button Sellection;
    [SerializeField] Button PutButton;

    public bool isSellectionIsOpen = false;
    public bool isSGuildIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        startUITextButton();
    }
    // Update is called once per frame
    void Update()
    {
        level.text = PlayerWhenStart.instance.level.ToString();
        //startUITextButton();
    }
    public void startUITextButton()
    {
        startUI.show();
    }
    public void endUITextButton()
    {
        startUI.close();
    }
    public void openSelectionButton()
    {
        if (!isSellectionIsOpen)
        {
            sellectionButton.show();
            isSellectionIsOpen = true;
            Guild.interactable = false;
            Resset.interactable = false;
            PutButton.interactable = false;
        }
        else if (isSellectionIsOpen)

        {
            sellectionButton.close();
            isSellectionIsOpen = false;
            Guild.interactable = true;
            Resset.interactable = true;
            PutButton.interactable = true;
        }
        
    }
    public void openGuildButton()
    {
        if (!isSGuildIsOpen)
        {
            guildButton.show();
            isSGuildIsOpen = true;
            Sellection.interactable = false;
            Resset.interactable = false;
            PutButton.interactable = false;
        }
        else if (isSGuildIsOpen)
        {
            guildButton.close();
            isSGuildIsOpen = false;
            Sellection.interactable = true;
            Resset.interactable = true;
            PutButton.interactable = true;
        }
    }
    public void transToMenu()
    {
        StartCoroutine(delayTransMenu());
    }
    IEnumerator delayTransMenu()
    {
        loadTrans.show();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(delayLoadMenu());
    }
    IEnumerator delayLoadMenu()
    {
        loadTrans.close();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(0);
    }

    //[System.Obsolete]
    [System.Obsolete]
    public void reload()
    {
        //reloadTrans.show();
        //GenMap.instance.DestroyMap();
        //GenMap.instance.DestroyTool();
        StartCoroutine(delayDestroy());
        StartCoroutine(PlayerController.instance.destroyClone());
        StartCoroutine(delay());
        //PlayerWhenStart.instance.setLevel(PlayerWhenStart.instance.level);
        //Player.transform.position = new Vector3(0, 3, 0);
        //Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        //if (PlayerWhenStart.instance.level!=4&& PlayerWhenStart.instance.level != 5)
        //{
        //    winCheck.instance.checkWin();
        //}
        //reloadTrans.close();


    }
    public void closeGuide()
    {
        guideDialog.close();
    }
    public IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(0.4f);
        GenMap.instance.DestroyMap();
        GenMap.instance.DestroyTool();
    }
    [System.Obsolete]
    public IEnumerator delay()
    {
        yield return new WaitForSeconds(0.6f);
        PlayerWhenStart.instance.setLevel(PlayerWhenStart.instance.level);
        Player.transform.position = new Vector3(0, 3, 0);
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (PlayerWhenStart.instance.level != 4 && PlayerWhenStart.instance.level != 5)
        {
            winCheck.instance.checkWin();
        }

    }
    //public void changeCamera()
    //{
    //    Camera.SetActive(true);
    //}
}
