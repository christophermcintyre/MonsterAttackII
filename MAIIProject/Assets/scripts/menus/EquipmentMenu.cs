using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EquipmentMenu : Menu {

	public Image portrait;

	public Text characterName;
	public Text characterJob;

	public Text itemName;
	public Text itemLVL;
	public Text itemType;
	public Text itemEXP;
	public Text itemBaseStat;
	public Text itemDelay;

	public GameObject itemListPanel;
	public ListItem listItemPrefab;
	public List<ListItem> itemDisplayList = new List<ListItem>();
	public StatItem selectedItem;

	public Item.ItemType iType;
	public int selectedSlot;

	public override void close(){

		foreach (ListItem obj in itemDisplayList) {
			Destroy (obj.gameObject);
		}

		itemDisplayList.Clear ();
		selectedItem = null;
	}

	public override void open(){

		displayList (validItems());

		portrait.color = new Color32(255, 255, 255, 255);
		portrait.sprite = activeCharacter.Portrait;
		
		characterName.text = activeCharacter.Name;
		characterJob.text = "LVL " + activeCharacter.CurrentJob.Level + " " + activeCharacter.CurrentJob.Name;

		refresh ();
	}

	public void displayList(List<StatItem> items){
		foreach (StatItem i in items) {
			ListItem l = (ListItem)Instantiate(listItemPrefab);
			itemDisplayList.Add(l);
			l.displayItem(i);
			l.transform.SetParent(itemListPanel.transform, false);
		}
	}

	public override void refresh(){

		foreach (ListItem obj in itemDisplayList) {
			obj.transform.GetChild (1).GetComponent<Text>().color = new Color(255,255,255);
		}

		if (selectedItem == null) {
			selectedItem = (StatItem)itemDisplayList[0].item;
		}
		
		if (selectedItem != null) {
			
			itemName.text = selectedItem.DisplayName;
			itemLVL.text  = ("LVL: " + selectedItem.Level);			
			itemEXP.text = ("EXP: " + selectedItem.CurrentExp + "/" + selectedItem.expToLevel);
			
			
			if(selectedItem.itemType == Item.ItemType.ACCESSORY){
				Accessory selectedAcc = (Accessory)selectedItem;
				itemType.text = ("Type: " + selectedAcc.AccessoryType);
				itemBaseStat.text = ("DEF: " + selectedAcc.Armor);
				itemDelay.text = "";
			}
			
			if(selectedItem.itemType == Item.ItemType.WEAPON){
				Weapon selectedWeapon = (Weapon)selectedItem;
				itemType.text = ("Type: " + selectedWeapon.WeaponType);
				itemBaseStat.text = ("DMG: " + selectedWeapon.Damage);
				itemDelay.text = ("Delay: " + selectedWeapon.Delay);
			}			
		}
	}
	//potential to move to ListItem
	public void equipItem(){

		switch (selectedSlot) {

		case 0:
			if (activeCharacter.mainWeapon != null) {
				//character.mainWeapon.equipped = false;
				player.inventory.add(activeCharacter.mainWeapon);
			}
			activeCharacter.mainWeapon = (Weapon)selectedItem;
			player.inventory.Items.Remove(selectedItem);
			//selectedItem.equipped = true;
			break;

		case 1:
			if (activeCharacter.offHandWeapon != null) {
				//character.offHandWeapon.equipped = false;
				player.inventory.add(activeCharacter.offHandWeapon);
			}
			activeCharacter.offHandWeapon = (Weapon)selectedItem;
			player.inventory.Items.Remove(selectedItem);
			//selectedItem.equipped = true;
			break;

		case 2:
			if (activeCharacter.accessory1 != null) {
				//character.accessory1.equipped = false;
				player.inventory.add(activeCharacter.accessory1);
			}
			activeCharacter.accessory1 = (Accessory)selectedItem;
			player.inventory.Items.Remove(selectedItem);
			//selectedItem.equipped = true;
			break;

		case 3:
			if (activeCharacter.accessory2 != null) {
				//character.accessory2.equipped = false;
				player.inventory.add(activeCharacter.accessory2);
			}
			activeCharacter.accessory2 = (Accessory)selectedItem;
			player.inventory.Items.Remove(selectedItem);
			//selectedItem.equipped = true;
			break;
		}

	}

	public List<StatItem> validItems(){

		List<StatItem> items = new List<StatItem> ();;

		switch(iType) {

		case Item.ItemType.WEAPON: 
			//Debug.Log ("looking for righthanded items");
			foreach(StatItem i in player.inventory.Items){
				if (i.itemType == Item.ItemType.WEAPON){
					if (!i.equipped) items.Add(i);
					//if (i.equipped() && i.owner == character) items.Add(i);
				}
			}
			break;
		
		case Item.ItemType.ACCESSORY:
			//Debug.Log ("looking for accessories");
			foreach(StatItem i in player.inventory.Items){
				if (i.itemType == Item.ItemType.ACCESSORY){
					if (!i.equipped) items.Add(i);
					//if (i.equipped() && i.owner == character) items.Add(i);
				}
			}
			break;	
		}
		return items; 
	}
}
