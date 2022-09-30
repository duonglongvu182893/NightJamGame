using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions.Tween;
using UnityEngine.UI;
using EazyEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] UIElement startUI;
    [SerializeField] UIElement sellectionButton;
    [SerializeField] UIElement guildButton;
    [SerializeField] TweenPlayer testTing;

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
}
