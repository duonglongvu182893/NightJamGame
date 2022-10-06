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
    [SerializeField] UIElement settingDialog;
    [SerializeField] GameObject buttonOndiaglog;
    [SerializeField] GameObject buttonOnSetting;
    [SerializeField] Sprite buttonOn;
    [SerializeField] Sprite buttonOff;

    [SerializeField] GameObject lv1;
    [SerializeField] GameObject lv3;
    [SerializeField] GameObject lv4;

    [SerializeField] Slider slideBG;

    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI numberCube;
    [SerializeField] TextMeshProUGUI countTime;

    [SerializeField] TweenPlayer testTing;
    [SerializeField] GameObject Player;

    //[SerializeField] GameObject Camera;
 
    [SerializeField] Button Resset;
    [SerializeField] Button Guild;
    [SerializeField] Button Sellection;
    [SerializeField] Button PutButton;
    [SerializeField] Button menuButton;
    

    public bool isSellectionIsOpen = false;
    public bool isSGuildIsOpen = false;
    public bool isSettingIsOpen = false;

    //public bool runLevel6 = false;

    // Start is called before the first frame update
    void Start()
    {   
        startUITextButton();
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
        //slideEf.onValueChanged.AddListener(val => SoundManager.instance.changeMasterVolume(val));
    }
    // Update is called once per frame
    void Update()
    {
        level.text = PlayerWhenStart.instance.level.ToString();
        numberCube.text = PlayerWhenStart.instance.numberOfClone.ToString();
        //startUITextButton();
        if (slideBG.value == 0)
        {
            buttonOndiaglog.GetComponent<Image>().sprite = buttonOff;
            buttonOnSetting.GetComponent<Image>().sprite = buttonOff;

        }
        else if (slideBG.value > 0)
        {
            buttonOndiaglog.GetComponent<Image>().sprite = buttonOn;
            buttonOnSetting.GetComponent<Image>().sprite = buttonOn;

        }
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
            PlayerController.instance.isUsingUI = true;
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
            PlayerController.instance.isUsingUI = false;
        }
        
    }
    public void openGuildButton()
    {
        if (!isSGuildIsOpen)
        {
            guildButton.show();
            isSGuildIsOpen = true;
            PlayerController.instance.isUsingUI = true;
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
            PlayerController.instance.isUsingUI = false;
        }
    }
    public void openSettingButton()
    {
        if (!isSettingIsOpen)
        {
            settingDialog.show();
            isSettingIsOpen = true;
            PlayerController.instance.isUsingUI = true;
            Sellection.interactable = false;
            Resset.interactable = false;
            menuButton.interactable = false;
            PutButton.interactable = false;
        }
        else if (isSettingIsOpen)
        {
            settingDialog.close();
            isSettingIsOpen = false;
            Sellection.interactable = true;
            Resset.interactable = true;
            menuButton.interactable = true ;
            PutButton.interactable = true;
            PlayerController.instance.isUsingUI = false;
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
        StartCoroutine(delayDestroy());
        StartCoroutine(PlayerController.instance.destroyClone());
        StartCoroutine(delay());
       

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
    public void changeVolume()
    {
        AudioListener.volume = slideBG.value;
        save();
    }
    public void Load()
    {
        slideBG.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void save()
    {
        PlayerPrefs.SetFloat("musicVolume", slideBG.value);
    }
    public void offMusic()
    {
        slideBG.value = 0;
       
    }
    //public void startLevel6
    //{

    //}

}
