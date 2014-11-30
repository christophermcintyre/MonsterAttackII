using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item {

	private int itemID;
	private string itemName;
	private string itemDescription;

	public enum ItemTypes{
		WEAPON,
		ACCESSORY,
		CONSUMABLE,
		CARD,
		MISC
	}

	private ItemTypes itemType;

	public Item(){}

	public Item(Dictionary<string, string> itemsDictionary) {
		itemName = itemsDictionary["ItemName"];
		itemID = int.Parse(itemsDictionary["ItemID"]);
		itemType = (ItemTypes)System.Enum.Parse(typeof(Item.ItemTypes), itemsDictionary["ItemType"].ToString());
	}


	//getters and setters

	public string ItemName{
		get{ return itemName;}
		set{ itemName = value;}
	}

	public string ItemDescription{
		get{ return itemDescription;}
		set{ itemDescription = value;}
	}

	public int ItemID{
		get{ return itemID;}
		set{ itemID = value;}
	}

	public ItemTypes ItemType{
		get{ return itemType;}
		set{ itemType = value;}
	}

}
