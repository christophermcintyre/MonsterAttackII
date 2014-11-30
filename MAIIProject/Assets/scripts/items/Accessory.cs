using UnityEngine;
using System.Collections;

public class Accessory : StatItem {

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

	private AccessoryTypes accessoryType;

	private int armor;

	public Accessory(string name, AccessoryTypes at, int arm){
		ItemName = name;
		accessoryType = at;
		armor = arm;
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

