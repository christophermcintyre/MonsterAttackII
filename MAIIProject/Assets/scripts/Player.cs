using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	//public ItemDatabase itemDatabase;
	//public CharacterDatabase characterDatabase;
	//public BattleDatabase battleDatabase;

	private static Player instance = null;
	
	public static Player Instance {
		get {
			if (instance == null) {
				Debug.Log("Instancing a new Player");
				GameObject go = Instantiate(Resources.Load ("Prefab/Player")) as GameObject;
				go.name = "Player";
			}
			return instance;
		}
	}

	public string playerName;
	public List<BaseCharacter> playerParty;
	public Inventory inventory;
	
	private int funds;
	private int wins;
	private int defeats;


	void Awake(){
		instance = this;
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {

		//Debug.Log ("Starting Player");

		playerName = "Player";
		inventory = new Inventory ();

		playerParty.Add(CharacterDatabase.Instance.getCharacterByName("Calais"));
		playerParty[0].mainWeapon = (Weapon)ItemDatabase.Instance.getItemByName("Dagger");
		playerParty[0].accessory1 = (Accessory)ItemDatabase.Instance.getItemByName ("Bandit Neckerchief");

		playerParty.Add(CharacterDatabase.Instance.getCharacterByName("Zetes"));
		playerParty[1].mainWeapon = (Weapon)ItemDatabase.Instance.getItemByName("Leather Gloves");
		playerParty[1].accessory1 = (Accessory)ItemDatabase.Instance.getItemByName ("Lucky Bell");


		inventory.add (ItemDatabase.Instance.getItemByName ("Wooden Sword"));

		//inventory.add (itemDatabase.getItemByName ("Dagger"));
		//inventory.add (itemDatabase.getItemByName ("Apprentice Wand"));
		//inventory.add (itemDatabase.getItemByName ("Novice Staff"));
		//inventory.add (itemDatabase.getItemByName ("Leather Gloves"));
		//inventory.add (itemDatabase.getItemByName ("Bronze Sword"));
		//inventory.add (itemDatabase.getItemByName ("Maple Harp"));
		//inventory.add (itemDatabase.getItemByName ("Slingshot"));
		//inventory.add (itemDatabase.getItemByName ("Teddy Bear"));
		//inventory.add (itemDatabase.getItemByName ("Plush Bunny"));
		//inventory.add (itemDatabase.getItemByName ("Boomerang"));
		
		//inventory.add (itemDatabase.getItemByName ("Wool Cape"));
		//inventory.add (itemDatabase.getItemByName ("Silk Cape"));
		//inventory.add (itemDatabase.getItemByName ("Green Ribbon"));
		//inventory.add (itemDatabase.getItemByName ("Silver Circlet"))
		inventory.add (ItemDatabase.Instance.getItemByName ("Spiked Bell"));
		inventory.add (ItemDatabase.Instance.getItemByName ("Magic Bell"));;

	}

	public void win(){
		wins++;
	}
	
	public void defeat(){
		defeats++;
		removeMoney((int) (0.1 * funds));
		revive ();
	}
	
	public void revive(){
		foreach(BaseCharacter c in playerParty){
			c.revive(false);
			
		}
	}

	public void addMoney(int f){
		funds += f;
	}
	
	public void removeMoney(int f){
		funds -= f;
		if (funds < 0)	funds = 0;
	}

	public void addExp(int xp, bool shareWithDefeated){
		
		if(shareWithDefeated) {
			foreach(BaseCharacter c in playerParty){
				c.CurrentJob.addExp(xp / playerParty.Count);
				//c.addEquipmentEXP(xp / members.Count);
			}
			
		} else {
			int livePartySize = 0;
			foreach(BaseCharacter c in playerParty){
				if (c.alive()){
					livePartySize++;
				}
			}
			
			int sharedEXP = (xp / livePartySize);
			foreach(BaseCharacter c in playerParty){
				if (c.alive()){
					c.CurrentJob.addExp(sharedEXP);
					//c.addEquipmentEXP(sharedEXP);
				}
			}
		}
	}
}
