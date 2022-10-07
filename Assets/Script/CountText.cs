using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountText : MonoBehaviour
{
    public float currentTime = 5;
    public TextMeshProUGUI text;
    public GameObject textCount;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.instance.isUsingUI = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        text.text = ((int)currentTime).ToString();
        if (currentTime <= 0)
        {
            PlayerController.instance.isUsingUI = false;
            StartCoroutine(delay());
        }
    }
    private void OnEnable()
    {
        currentTime = 5;
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
