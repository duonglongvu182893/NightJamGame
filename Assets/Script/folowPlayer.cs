using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;

    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = ()
        //distance = transform.position - player.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.position.x + distance.x, player.position.y, player.position.z + distance.z);
        transform.position = player.transform.position;
    }
}
