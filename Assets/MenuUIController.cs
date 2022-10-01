using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] GameObject efectChar;
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
}
