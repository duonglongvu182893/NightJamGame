using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions.Tween;

public class winCheck : MonoBehaviour
{
    public static winCheck instance;
    //[SerializeField] TweenPlayer fallDown;
    [SerializeField] GameObject star;
    [SerializeField] GameObject Fx;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //checkWin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkWin()
    {
        StartCoroutine(ifFXEnable());
        star.SetActive(true);
        star.GetComponent<TweenPlayer>().ForcePlayRuntime();
      
    }
    public void disbaleWin()
    {
        star.GetComponent<TweenPlayer>().ForcePlayBackRuntime();
    }
    IEnumerator ifFXEnable()
    {
        Fx.SetActive(true);
        yield return new WaitForSeconds(1f);
        Fx.SetActive(false);

    }
       
      
    
}
