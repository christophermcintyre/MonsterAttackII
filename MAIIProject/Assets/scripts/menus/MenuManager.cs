using UnityEngine;
using System.Collections;

//opens and closes menus
public class MenuManager : MonoBehaviour {

	public Player player;
	public Menu currentMenu;

	public void closeMenu (Menu menu){
		//Camera.main.GetComponent<CameraController>().enabled = true;
		//Player.Instance.playerAvatar.GetComponent<PlayerController>().enabled = true;
		currentMenu.IsOpen = false;
		menu.close ();
	}

	public void showMenu(Menu menu){
		if (currentMenu != null) { //closes current menu if there is one open
			currentMenu.IsOpen = false;
			currentMenu.close();
		}
		//Camera.main.GetComponent<CameraController>().enabled = false;
		//Player.Instance.playerAvatar.GetComponent<PlayerController>().enabled = false;
		currentMenu = menu;
		currentMenu.IsOpen = true;
		currentMenu.open ();
	}
}
