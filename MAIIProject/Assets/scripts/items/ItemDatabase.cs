using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public static ItemDatabase instance;
	private static List<Item> items = new List<Item>();

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
		instance = this;
		//buildItems ();
	}

	public void Start(){
		buildItems ();
	}

	public Item getItemByID(int itemID){

		foreach (Item i in items){

			if(i.itemID == itemID){
				return copyItem(i);
			}
		}
		return null;
	}

	public Item getItemByName(string name) {

		foreach (Item j in items){

			if(j.DisplayName == name){
				return copyItem(j);
			}
		}
		return null;
	}

	private Item copyItem(Item template){

		Item copy = null;

		switch(template.itemType){

		case Item.ItemType.ACCESSORY:
			copy = new Accessory((Accessory)template);
			break;

		case Item.ItemType.CARD:
			//copy = new Card(template);
			break;

		case Item.ItemType.CONSUMABLE:
			//copy = new Consumable(template);
			break;

		case Item.ItemType.KEY_ITEM:
			//copy = new Misc(template);
			break;

		case Item.ItemType.WEAPON:
			copy = new Weapon((Weapon)template);
			break;

		}
		return copy;

	}

	public void buildItems(){

		//Debug.Log("building item database");

		//Fighter's gloves
		items.Add(new Weapon("glove0", "Leather Gloves", 10, Weapon.WeaponTypes.GLOVE, 18, 100));

		//Daggers
		items.Add(new Weapon("dagger0", "Dagger", 10, Weapon.WeaponTypes.DAGGER, 24, 150));

		//Staffs and Rods
		items.Add (new Weapon ("staff0", "Novice Staff", 10, Weapon.WeaponTypes.STAFF, 30, 300));

		//Wands and sceptres
		items.Add (new Weapon ("wand0", "Apprentice Wand", 10, Weapon.WeaponTypes.WAND, 30, 300));

		//Flutes
		items.Add(new Weapon("flute0", "Faerie Flute", 10, Weapon.WeaponTypes.FLUTE, 10, 175));

		//Harps
		items.Add(new Weapon("harp0", "Maple Harp", 10, Weapon.WeaponTypes.HARP, 18, 300));

		//Small swords
		items.Add(new Weapon("sword0", "Wooden Sword", 5, Weapon.WeaponTypes.SWORD, 22, 200));	
		items.Add(new Weapon("sword1", "Bronze Sword", 10, Weapon.WeaponTypes.SWORD, 30, 200));

		//Slingshots
		items.Add (new Weapon ("sling0", "Slingshot", 10, Weapon.WeaponTypes.SLINGSHOT, 10, 100));

		//Boomerangs
		items.Add (new Weapon ("boomerang0", "Boomerang", 10, Weapon.WeaponTypes.BOOMERANG, 20, 150));

		//Toys and dolls
		items.Add(new Weapon("toy0", "Teddy Bear", 10, Weapon.WeaponTypes.TOY, 15, 200));
		items.Add(new Weapon("toy1", "Plush Bunny", 20, Weapon.WeaponTypes.TOY, 15, 200));
		
		/*
		 * 
		//Large Swords
		items.Add(new Weapon("Bronze Greatsword", Weapon.WeaponTypes.GREATSWORD, 60, 400));

		//Axes
		items.Add(new Weapon("Bronze Axe", Weapon.WeaponTypes.AXE, 34, 250));

		//Maces
		items.Add(new Weapon("Club", Weapon.WeaponTypes.MACE, 25, 175));

		//Spears and Lances
		items.Add (new Weapon ("Wooden Spear", Weapon.WeaponTypes.LANCE, 40, 300));

		//Bows
		items.Add (new Weapon ("Short Bow", Weapon.WeaponTypes.BOW, 30, 300));

		//Crossbows
		items.Add (new Weapon ("Crossbow", Weapon.WeaponTypes.CROSSBOW, 30, 300));

		//Whips
		items.Add (new Weapon ("Whip", Weapon.WeaponTypes.WHIP, 30, 300));
		
		//Violins
		items.Add(new Weapon("Violin", Weapon.WeaponTypes.VIOLIN, 20, 220));
		*/

		//Catbells
		items.Add(new Accessory("catbell0", "Lucky Bell", 10, Accessory.AccessoryTypes.CATBELL, 5));
		items.Add(new Accessory("catbell1", "Spiked Bell", 20, Accessory.AccessoryTypes.CATBELL, 5));
		items.Add(new Accessory("catbell2", "Magic Bell", 40, Accessory.AccessoryTypes.CATBELL, 5));

		items.Add(new Accessory("cape0", "Wool Cape", 10, Accessory.AccessoryTypes.CAPE, 5));
		items.Add(new Accessory("cape1", "Silk Cape", 20, Accessory.AccessoryTypes.CAPE, 5));
		items.Add(new Accessory("ribbon0", "Green Ribbon", 10, Accessory.AccessoryTypes.RIBBON, 5));
		items.Add(new Accessory("circlet0", "Silver Circlet", 20, Accessory.AccessoryTypes.CIRCLET, 5));
		items.Add(new Accessory("scarf0", "Bandit Neckerchief", 10, Accessory.AccessoryTypes.SCARF, 5));


	

	}

}
