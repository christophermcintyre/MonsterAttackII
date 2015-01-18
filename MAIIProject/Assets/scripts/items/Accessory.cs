using UnityEngine;
using System.Collections;

public class Accessory : StatItem {

	private int armor;
	private AccessoryTypes accessoryType;

	public enum AccessoryTypes {

		CATBELL,
		SCARF,
		SHIELD,
		CAPE,
		RIBBON,
		CIRCLET,
		CODPIECE,
		BRACER,
		SHOES,
		EARRING
	}



	public Accessory(string name, string display, int value, AccessoryTypes at, int arm){
		ItemName = name;
		DisplayName = display;
		itemIcon = Resources.Load<Sprite> ("" + name);

		itemType = ItemType.ACCESSORY;
		accessoryType = at;

		armor = arm;
		itemValue = value;



	}

	public Accessory (Accessory template){
		ItemName = template.ItemName;
		DisplayName = template.DisplayName;
		itemIcon = template.itemIcon;

		itemType = ItemType.ACCESSORY;
		AccessoryType = template.AccessoryType;

		Armor = template.Armor;
		itemValue = template.itemValue;
		LevelReq = template.LevelReq;
	}


	public Accessory(){

	}

	//getters/setters
	public AccessoryTypes AccessoryType {
		get{ return accessoryType;}
		set{ accessoryType = value;}
	}

	public int Armor {
		get{return armor;}
		set{armor = value;}
	}
}

