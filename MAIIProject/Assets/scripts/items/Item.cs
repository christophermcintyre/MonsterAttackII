using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item {

	public int itemID;
	public string itemName;
	public string displayName;
	public string itemDesc;
	public Sprite itemIcon;
	public ItemType itemType;
	public int itemValue;
	public int maxStackSize;
	public int currentStackSize;

	public enum ItemType{
		WEAPON,
		ACCESSORY,
		CONSUMABLE,
		CARD,
		KEY_ITEM
	}

	public Item(){}

	public string ItemName{
		get{ return itemName;}
		set{ itemName = value;}
	}

	public string DisplayName{
		get{ return displayName;}
		set{ displayName = value;}
	}

	public string ItemDesc{
		get{ return itemDesc;}
		set{ itemDesc = value;}
	}

	public int ItemID{
		get{ return itemID;}
		set{ itemID = value;}
	}

	public int ItemValue{
		get{ return itemValue;}
		set{ itemValue = value;}
	}

}
