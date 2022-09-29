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
			//StartCoroutine(delay());
			//player.transform.position = new Vector3(0, 0, 0);
			PlayerWhenStart.instance.level++;
			GenMap.instance.DestroyTool();
			StartCoroutine(PlayerWhenStart.instance.destroyOldPlatform(PlayerWhenStart.instance.level));
            
        }

		//IEnumerator delay()
  //      {
		//	StartCoroutine(PlayerController.instance.destroyClone());
		//	yield return new WaitForSeconds(1f);
		//}
    }
}
