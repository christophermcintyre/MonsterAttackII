using UnityEngine;
using System.Collections;

//opens and closes menus

public class MenuManager : MonoBehaviour {

	public Player player;
	public Menu currentMenu;

	public void Start(){
		//showMenu (currentMenu);
	}

	public void closeMenu (Menu menu){
		menu.close ();
	}

	public void showMenu(Menu menu){
		if (currentMenu != null) { //closes current menu if there is one open
			currentMenu.close();
			currentMenu.IsOpen = false;
		}
		currentMenu = menu;
		currentMenu.IsOpen = true;
		currentMenu.open ();
	}
}
