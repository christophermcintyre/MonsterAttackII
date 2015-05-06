using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryMenu : Menu {

	//public Image portrait;
	
	//public Text characterName;
	//public Text characterJob;
	
	public Text itemName;
	//public Text itemLVL;
	public Text itemType;
	//public Text itemEXP;
	//public Text itemBaseStat;
	//public Text itemDelay;
	
	public GameObject itemListPanel;
	public ListItem listItemPrefab;
	public List<ListItem> itemDisplayList = new List<ListItem>();
	public Item selectedItem;
	
	//public Item.ItemType iType;
	//public int selectedSlot;
	
	public override void close(){
		
		foreach (ListItem obj in itemDisplayList) {
			Destroy (obj.gameObject);
		}
		
		itemDisplayList.Clear ();
		selectedItem = null;
	}
	
	public override void open(){

		displayList (player.inventory.Items);
		
		//portrait.color = new Color32(255, 255, 255, 255);
		//portrait.sprite = character.Portrait;
		
		//characterName.text = character.Name;
		//characterJob.text = "LVL " + character.CurrentJob.Level + " " + character.CurrentJob.Name;
		
		refresh ();
	}
	
	public void displayList(List<Item> items){
		foreach (Item i in items) {
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
			selectedItem = itemDisplayList[0].item;
		}
		
		if (selectedItem != null) {
			
			itemName.text = selectedItem.DisplayName;
			//itemLVL.text  = ("LVL: " + selectedItem.Level);			
			//itemEXP.text = ("EXP: " + selectedItem.CurrentExp + "/" + selectedItem.expToLevel);			
			
			if(selectedItem.itemType == Item.ItemType.ACCESSORY){
				Accessory selectedAcc = (Accessory)selectedItem;
				itemType.text = ("Type: " + selectedAcc.AccessoryType);
				//itemBaseStat.text = ("DEF: " + selectedAcc.Armor);
				//itemDelay.text = "";
			}
			
			if(selectedItem.itemType == Item.ItemType.WEAPON){
				Weapon selectedWeapon = (Weapon)selectedItem;
				itemType.text = ("Type: " + selectedWeapon.WeaponType);
				//itemBaseStat.text = ("DMG: " + selectedWeapon.Damage);
				//itemDelay.text = ("Delay: " + selectedWeapon.Delay);
			}			
		}
	}

	//potential to move to ListItem
	public void useItem(){		
	}
	
	public List<Item> validItems(){
		
		List<Item> items = new List<Item> ();
		return items; 
	}
}


