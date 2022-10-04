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

    
    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
