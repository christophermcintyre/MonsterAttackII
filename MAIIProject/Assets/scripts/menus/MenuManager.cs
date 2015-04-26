using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Player player;

	public Menu currentMenu;
	public BaseCharacter selectedCharacter;
	public int selectedSlot;
	public Item.ItemType itemType;

	public void Start(){

		if (player.playerParty != null) selectedCharacter = player.playerParty[0];

		//showMenu (currentMenu);
	}

	public void selectCharacter(int characterIndex) {

		selectedCharacter = player.playerParty[characterIndex];

	}

	public void selectSlot(int itemSlot) {
		//selectedSlot = selectedCharacter.equipmentSlots [itemSlot];
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
		//currentMenu.DisplaySlot (selectedSlot);
		currentMenu.open ();
	}
}
