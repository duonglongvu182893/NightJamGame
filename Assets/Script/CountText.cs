using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountText : MonoBehaviour
{
    public float currentTime = 5;
    public TextMeshProUGUI text;
    public GameObject textCount;
    public Button reloadButton;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.instance.isUsingUI = true;
    }
    
    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        text.text = ((int)currentTime).ToString();
        if (currentTime <= 0)
        {
            PlayerController.instance.isUsingUI = false;
            reloadButton.interactable = true;
            StartCoroutine(delay());
        }
    }
    private void OnEnable()
    {
        currentTime = 5;
        PlayerController.instance.isUsingUI = true;
        reloadButton.interactable = false;
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
