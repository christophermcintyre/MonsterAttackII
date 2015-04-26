using UnityEngine;
using System.Collections;

public class Construction : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	}



	void OnTriggerEnter (Collider info) {
		
		if (info.tag == "Player") {
			info.GetComponent<PlayerController>().activeObjects.Add(this.gameObject);
		}
	}

	void OnTriggerExit (Collider info) {

		if (info.tag == "Player") {
			if (info.GetComponent<PlayerController>().activeObjects.Contains(this.gameObject)){
				info.GetComponent<PlayerController>().activeObjects.Remove(this.gameObject);
			}
		}
	}
}
