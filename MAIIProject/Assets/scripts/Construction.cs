using UnityEngine;
using System.Collections;

public class Construction : MonoBehaviour {

	//public GameObject player;
	
	void Start () {
		
		//player = GameObject.FindWithTag("Player");
		
	}
	
	void Update () {
		
		//if (Vector3.Distance (player.transform.position, transform.position) < 1){
			//player.GetComponent<PlayerController>().lastActive = this.gameObject;
		//}
	}


	void OnTriggerEnter (Collider info) {
		
		if (info.tag == "Player") {
			//info.GetComponent<PlayerController>().lastActive = this.gameObject;
			info.GetComponent<PlayerController>().activeObjects.Add(this.gameObject);
			//player.GetComponent<PlayerController>().lastActive = this.gameObject;
		}
	}

	void OnTriggerExit (Collider info) {

		if (info.tag == "Player") {
			if (info.GetComponent<PlayerController>().activeObjects.Contains(this.gameObject)){
				info.GetComponent<PlayerController>().activeObjects.Remove(this.gameObject);
			}			
			//if (info.GetComponent<PlayerController>().lastActive == this.gameObject){
			//	info.GetComponent<PlayerController>().lastActive = null;
			//}
		}
	}
}
