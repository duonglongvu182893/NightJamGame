using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions.Tween;
using UnityEngine.UI;
using EazyEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    [SerializeField] UIElement startUI;
    [SerializeField] UIElement sellectionButton;
    [SerializeField] UIElement guildButton;
    [SerializeField] UIElement loadTrans;
    [SerializeField] TweenPlayer testTing;
    [SerializeField] GameObject Player;
    //[SerializeField] GameObject Camera;
 
    [SerializeField] Button Resset;
    [SerializeField] Button Guild;
    [SerializeField] Button Sellection;

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
        }
        else if (isSellectionIsOpen)

        {
            sellectionButton.close();
            isSellectionIsOpen = false;
            Guild.interactable = true;
            Resset.interactable = true;
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
        }
        else if (isSGuildIsOpen)
        {
            guildButton.close();
            isSGuildIsOpen = false;
            Sellection.interactable = true;
            Resset.interactable = true;
        }
    }
    public void transToMenu()
    {
        StartCoroutine(delayTransMenu());
    }
    IEnumerator delayTransMenu()
    {
        loadTrans.show();
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(delayLoadMenu());
    }
    IEnumerator delayLoadMenu()
    {
        loadTrans.close();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }

    //[System.Obsolete]
    [System.Obsolete]
    public void reload()
    {
        GenMap.instance.DestroyMap();
        GenMap.instance.DestroyTool();
        PlayerWhenStart.instance.setLevel(PlayerWhenStart.instance.level);
        PlayerController.instance.destroyClone();
        Player.transform.position = new Vector3(0, 3, 0);
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (PlayerWhenStart.instance.level!=4&& PlayerWhenStart.instance.level != 5)
        {
            winCheck.instance.checkWin();
        }

        
    }
    //public void changeCamera()
    //{
    //    Camera.SetActive(true);
    //}
}
