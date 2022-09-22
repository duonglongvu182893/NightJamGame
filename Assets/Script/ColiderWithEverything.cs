using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColiderWithEverything : MonoBehaviour
{
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkedMove()
    {
        if (PlayerMovement.instance.isPress)
        {
            Player.transform.DOScale(transform.position - new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
