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

	public void displayList(List<Item> items){
		foreach (StatItem i in items) {
			ListItem l = (ListItem)Instantiate(listItemPrefab);
			itemDisplayList.Add(l);
			l.displayItem(i);
			l.transform.SetParent(itemListPanel.transform, false);
			l.parentMenu = this;

		}
	}

	public override void select(ListItem l){
		selectedItem = (StatItem)l.item;
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
				Player.Instance.inventory.add(activeCharacter.mainWeapon);
			}
			activeCharacter.mainWeapon = (Weapon)selectedItem;
			Player.Instance.inventory.Items.Remove(selectedItem);
			break;

		case 1:
			if (activeCharacter.offHandWeapon != null) {
				Player.Instance.inventory.add(activeCharacter.offHandWeapon);
			}
			activeCharacter.offHandWeapon = (Weapon)selectedItem;
			Player.Instance.inventory.Items.Remove(selectedItem);
			break;

		case 2:
			if (activeCharacter.accessory1 != null) {
				Player.Instance.inventory.add(activeCharacter.accessory1);
			}
			activeCharacter.accessory1 = (Accessory)selectedItem;
			Player.Instance.inventory.Items.Remove(selectedItem);
			break;

		case 3:
			if (activeCharacter.accessory2 != null) {
				Player.Instance.inventory.add(activeCharacter.accessory2);
			}
			activeCharacter.accessory2 = (Accessory)selectedItem;
			Player.Instance.inventory.Items.Remove(selectedItem);
			break;
		}

	}

	public List<Item> validItems(){

		List<Item> items = new List<Item> ();;

		switch(iType) {

		case Item.ItemType.WEAPON: 
			//Debug.Log ("looking for righthanded items");
			foreach(Item i in Player.Instance.inventory.Items){
				if (i.itemType == Item.ItemType.WEAPON){
					items.Add(i);
					//if (i.equipped() && i.owner == character) items.Add(i);
				}
			}
			break;
		
		case Item.ItemType.ACCESSORY:
			//Debug.Log ("looking for accessories");
			foreach(Item i in Player.Instance.inventory.Items){
				if (i.itemType == Item.ItemType.ACCESSORY){
					items.Add(i);
					//if (i.equipped() && i.owner == character) items.Add(i);
				}
			}
			break;	
		}
		return items; 
	}
}
