using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public ItemDatabase itemDatabase;
	public CharacterDatabase characterDatabase;
	public BattleDatabase battleDatabase;

	public string playerName;
	public List<BaseCharacter> playerParty;
	public Inventory inventory;
	
	private int funds;
	private int wins;
	private int defeats;

	void Awake(){

		DontDestroyOnLoad (transform.gameObject);

	}

	void Start () {

		playerName = "Player";
		inventory = new Inventory ();

		playerParty.Add(characterDatabase.getCharacterByName("Calais"));
		playerParty.Add(characterDatabase.getCharacterByName("Zetes"));

		inventory.add (itemDatabase.getItemByName ("Spiked Bell"));
		inventory.add (itemDatabase.getItemByName ("Magic Bell"));
		inventory.add (itemDatabase.getItemByName ("Dagger"));
		inventory.add (itemDatabase.getItemByName ("Apprentice Wand"));
		inventory.add (itemDatabase.getItemByName ("Novice Staff"));
		inventory.add (itemDatabase.getItemByName ("Leather Gloves"));
		inventory.add (itemDatabase.getItemByName ("Wooden Sword"));
		inventory.add (itemDatabase.getItemByName ("Bronze Sword"));
		inventory.add (itemDatabase.getItemByName ("Maple Harp"));
		inventory.add (itemDatabase.getItemByName ("Slingshot"));
		inventory.add (itemDatabase.getItemByName ("Teddy Bear"));
		inventory.add (itemDatabase.getItemByName ("Plush Bunny"));
		inventory.add (itemDatabase.getItemByName ("Boomerang"));
		
		inventory.add (itemDatabase.getItemByName ("Wool Cape"));
		inventory.add (itemDatabase.getItemByName ("Silk Cape"));
		inventory.add (itemDatabase.getItemByName ("Green Ribbon"));
		inventory.add (itemDatabase.getItemByName ("Silver Circlet"));
		inventory.add (itemDatabase.getItemByName ("Bandit Neckerchief"));

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

	//Do I need to add a player team?

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
