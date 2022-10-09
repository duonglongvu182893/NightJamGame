using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableFXWorldCube : MonoBehaviour
{
    public GameObject Fx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ifItColision()); 
    }
    IEnumerator ifItColision()
    {
        Fx.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Fx.SetActive(false);
    }
}
