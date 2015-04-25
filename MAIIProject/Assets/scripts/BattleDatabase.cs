using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleDatabase : MonoBehaviour {

	public CharacterDatabase characterDatabase;

	public List<Battle> battleList = new List<Battle>();


	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {

		//Debug.Log("Starting BattleDatabase");

		buildBattleDatabase ();
	}

	public void buildBattleDatabase(){

		Party demoParty = new Party (characterDatabase.monsters, "Training Battle");

		//battleList.Add (new Battle(rat))

		battleList.Add (new Battle(demoParty, "Training Battle", "A training fight against an automaton", 200, 200));

	}

	public Battle getBattleByName(string name){

		foreach (Battle b in battleList) {
			if (b.battleName == name){
				Debug.Log("Returning " + b.battleName);
				return b;
				//return copyBattle(b);
			}
		}
		return null;
	}

	public Battle copyBattle(Battle template){
		//Party copy = new Party (template.enemyParty);
		return new Battle (new Party (template.enemyParty), template.battleName, template.battleDesc, template.moneyValue, template.expValue);
	}
}
