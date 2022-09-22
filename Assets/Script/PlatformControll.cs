using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControll : MonoBehaviour
{
    public static PlatformControll instance;
    
    public float currentTime = 10;
    public float deleteTime = 5;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        //clonePlayer = new List<GameObject>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        
        //if (currentTime <= 0)
        //{
        //    PlayerMovement.instance.deleteClone();
        //    currentTime = 10;
        //}
        if (currentTime <= 0)
        {
            PlayerMovement.instance.enableClone();
            
        }
        

    }

}
