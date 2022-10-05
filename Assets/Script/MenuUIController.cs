using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EazyEngine.UI;
using UnityExtensions.Tween;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    
    [SerializeField] GameObject efectChar;
    [SerializeField] Button start;
    [SerializeField] UIElement transLevel;
    [SerializeField] UIElement settingDiaLog;
    [SerializeField] Slider slidebg;
    [SerializeField] GameObject button;
    [SerializeField] Sprite buttonOn;
    [SerializeField] Sprite buttonOff;



    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay());
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
        //if (slidebg.value == 0)
        //{
        //    button.GetComponent<Image>().sprite = buttonOff;
            
        //}
        //else if (slidebg.value > 0)
        //{
        //    button.GetComponent<Image>().sprite = buttonOn;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (slidebg.value == 0)
        {
            button.GetComponent<Image>().sprite = buttonOff;

        }
        else if (slidebg.value > 0)
        {
            button.GetComponent<Image>().sprite = buttonOn;
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        efectChar.SetActive(true);
    }

    public void transToNextLevel()
    {
        StartCoroutine(transToLevel());
    }
    IEnumerator transToLevel()
    {
        transLevel.show();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
    public void openSetTingDialog()
    {
        if (!isOpen)
        {
            settingDiaLog.show();
            start.interactable = false;
            isOpen = true;

        }
        else if (isOpen)
        {
            settingDiaLog.close();
            start.interactable = true;
            isOpen = false;

        }


    }
    public void changeVolume()
    {
        AudioListener.volume = slidebg.value;
        save();
    }
    public void Load()
    {
        slidebg.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void save()
    {
        PlayerPrefs.SetFloat("musicVolume", slidebg.value);
    }
    public void offMusic()
    {
        slidebg.value = 0;
        //button.GetComponent<Image>().sprite = buttonOff;
    }
}
