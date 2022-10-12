using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDesTroyPad : MonoBehaviour
{
    public float currentTime = 5;
    //bool isRun = false;
    // Start is called before the first frame update
    void Start()
    {
        Level6.instance.runlevel6 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Level6.instance.runlevel6)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
    //IEnumerator destroyPad()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Destroy(gameObject);
    //}
}
