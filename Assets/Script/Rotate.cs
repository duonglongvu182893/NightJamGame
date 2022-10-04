using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	//public GameObject player;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.back * Time.deltaTime * speed * 10);
	}

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {

            StartCoroutine(GenMap.instance.delayMap());
            //PlayerWhenStart.instance.level = PlayerWhenStart.instance.level + 1;
            if (PlayerWhenStart.instance.level == 1)
            {
                PlayerWhenStart.instance.level = 2;
            }
            else if (PlayerWhenStart.instance.level == 2)
            {
                PlayerWhenStart.instance.level = 3;
            }
            else if (PlayerWhenStart.instance.level == 3)
            {
                PlayerWhenStart.instance.level = 4;
            }
            GenMap.instance.DestroyTool();
            StartCoroutine(PlayerWhenStart.instance.destroyOldPlatform(PlayerWhenStart.instance.level));
            Debug.Log("+1");

        }

		
    }
	
}
