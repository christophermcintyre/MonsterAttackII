using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Menu currentMenu;
	public BaseCharacter selectedCharacter;
	public EquipmentSlot selectedSlot;

	public void Start(){

		if (Player.playerParty != null) selectedCharacter = Player.playerParty.getMembers ()[0];

		showMenu (currentMenu);
	}

	public void selectCharacter(int characterIndex) {

		selectedCharacter = Player.playerParty.getMembers ()[characterIndex];

	}

	public void selectSlot(int itemSlot) {
		selectedSlot = selectedCharacter.equipmentSlots [itemSlot];
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
		currentMenu.DisplayCharacter (selectedCharacter);
		currentMenu.DisplaySlot (selectedSlot);
		currentMenu.open ();
	}
}
