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
		buildBattleDatabase ();
	}

	public void buildBattleDatabase(){

		List<BaseCharacter> demoParty = new List<BaseCharacter> ();
		demoParty.Add (characterDatabase.getCharacterByName("Automaton"));
		demoParty.Add (characterDatabase.getCharacterByName("Ashley"));

		battleList.Add (new Battle(demoParty, "Training Battle", "A training fight against an automaton", 200, 200));

	}

	public Battle getBattleByName(string name){

		foreach (Battle b in battleList) {
			if (b.battleName == name){
				return b;
			}
		}
		return null;
	}
}
