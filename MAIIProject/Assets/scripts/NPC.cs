using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	public Menu dialogMenu;
	public MenuManager menuManager;

	void Start () {}

	void Update () {}

	void OnTriggerEnter (Collider info) {		
		if (info.tag == "Player") {
			if (dialogMenu) menuManager.showMenu(dialogMenu);
		}
	}
	
	void OnTriggerExit (Collider info) {		
		if (info.tag == "Player") {
			if (dialogMenu) menuManager.closeMenu(dialogMenu);
		}
	}
}
