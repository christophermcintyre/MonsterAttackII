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

	public ItemList listBox;
	public List<Item> items = new List<Item>();
	public StatItem selectedItem;

	public override void close(){

		listBox.closeList ();
		selectedItem = null;
	}

	public override void open(){

		listBox.displayList (validItems(slot));

		portrait.color = new Color32(255, 255, 255, 255);
		portrait.sprite = character.Portrait;
		
		characterName.text = character.Name;
		characterJob.text = "LVL " + character.CurrentJob.Level + " " + character.CurrentJob.Name;

		refresh ();
	}

	public override void refresh(){

		listBox.refresh ();

		if (selectedItem == null) {
			selectedItem = (StatItem)items[0];
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

	public void equipItem(){

		character.equip (selectedItem, slot);	
	}

	public List<Item> validItems(EquipmentSlot es){

		items.Clear();

		switch(es.SlotType) {

		case EquipmentSlot.SlotTypes.RIGHTHAND: 
			//Debug.Log ("looking for righthanded items");
			foreach(StatItem i in player.playerParty.inventory.Items){
				if (i.itemType == Item.ItemType.WEAPON){
					if (!i.equipped()) items.Add(i);
					if (i.equipped() && i.owner == character) items.Add(i);
				}
			}
			break;
		

		case EquipmentSlot.SlotTypes.LEFTHAND:
			//Debug.Log ("looking for lefthanded items");
			foreach(StatItem i in player.playerParty.inventory.Items){
				if (i.itemType == Item.ItemType.WEAPON){
					if (!i.equipped()) items.Add(i);
					if (i.equipped() && i.owner == character) items.Add(i);
				}
			}
			break;		


		case EquipmentSlot.SlotTypes.ACCESSORY:
			//Debug.Log ("looking for accessories");
			foreach(StatItem i in player.playerParty.inventory.Items){
				if (i.itemType == Item.ItemType.ACCESSORY){
					if (!i.equipped()) items.Add(i);
					if (i.equipped() && i.owner == character) items.Add(i);
				}
			}
			break;	
		}
		return items; 
	}
}
