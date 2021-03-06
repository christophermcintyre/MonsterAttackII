﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private static Player instance = null;
	
	public static Player Instance {
		get {
			if (instance == null) {
				//Debug.Log("Instancing a new Player");
				GameObject go = Instantiate(Resources.Load ("Prefab/Player")) as GameObject;
				go.name = "Player";
			}
			return instance;
		}
	}

	public PlayerController playerAvatar;

	public string playerName;
	public List<BaseCharacter> playerParty;
	public Inventory inventory;
	
	private int funds = 100;
	private int wins;
	private int defeats;


	void Awake(){
		instance = this;
		playerAvatar = GameObject.FindObjectOfType<PlayerController> ();
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {
		playerName = "Player";
		inventory = new Inventory ();

		playerParty.Add(CharacterDatabase.Instance.getCharacterByName("Calais"));
		playerParty[0].mainWeapon = (Weapon)ItemDatabase.Instance.getItemByName("Dagger");
		playerParty[0].accessory1 = (Accessory)ItemDatabase.Instance.getItemByName ("Bandit Neckerchief");

		playerParty.Add(CharacterDatabase.Instance.getCharacterByName("Zetes"));
		playerParty[1].mainWeapon = (Weapon)ItemDatabase.Instance.getItemByName("Leather Gloves");
		playerParty[1].accessory1 = (Accessory)ItemDatabase.Instance.getItemByName ("Lucky Bell");

		inventory.add (ItemDatabase.Instance.getItemByName("Potion"));
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

	public int Funds{
		get{return funds;}
		set{funds = value;}
	}
	
	public int Wins{
		get{return wins;}
		set{wins = value;}
	}
	
	public int Defeats{
		get{return defeats;}
		set{defeats = value;}
	}

}
