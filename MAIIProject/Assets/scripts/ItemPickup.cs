using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour {

	void OnTriggerEnter (Collider info) {

		if (info.tag == "Player") {

			info.GetComponent<PlayerController>().activeItems.Add(this);

			//info.GetComponent<PlayerController>().sticks +=1;
			//Destroy(gameObject);
		}
	}

	void OnTriggerExit (Collider info) {
		
		if (info.tag == "Player") {
			if (info.GetComponent<PlayerController>().activeItems.Contains(this)){
				info.GetComponent<PlayerController>().activeItems.Remove(this);
			}
		}
	}
}
