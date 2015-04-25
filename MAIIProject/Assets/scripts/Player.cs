using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//public static Player instance;
	public Party playerParty;
	public string playerName;
	//public static Party monsterParty;
	public ItemDatabase itemDatabase;
	public CharacterDatabase characterDatabase;
	public BattleDatabase battleDatabase;


	void Awake(){

		//QualitySettings.vSyncCount = 1;
		DontDestroyOnLoad (transform.gameObject);
		//instance = this;

	}

	void Start () {

		//itemDatabase = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
		//characterDatabase = GameObject.FindGameObjectWithTag ("CharacterDatabase").GetComponent<CharacterDatabase> ();
		//battleDatabase = GameObject.FindGameObjectWithTag ("BattleDatabase").GetComponent<BattleDatabase> ();

		playerName = "Player";
		playerParty = new Party (playerName);
		playerParty.addMembers (characterDatabase.characters);

		foreach (BaseCharacter character in playerParty.getMembers()) {
		//	foreach (EquipmentSlot slot in character.equipmentSlots){
		//		if(slot.EquippedItem != null){
		//			playerParty.inventory.add(slot.EquippedItem);
		///		}
		//	}
		}
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Spiked Bell"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Magic Bell"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Dagger"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Apprentice Wand"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Novice Staff"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Leather Gloves"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Wooden Sword"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Bronze Sword"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Maple Harp"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Slingshot"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Teddy Bear"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Plush Bunny"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Boomerang"));
		
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Wool Cape"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Silk Cape"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Green Ribbon"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Silver Circlet"));
		playerParty.inventory.add (ItemDatabase.instance.getItemByName ("Bandit Neckerchief"));


	}

}
