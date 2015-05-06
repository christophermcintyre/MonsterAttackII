using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleDatabase : MonoBehaviour {

	//public CharacterDatabase characterDatabase;

	private static BattleDatabase instance = null;

	public static BattleDatabase Instance {
		get {
			if (instance == null) {
				Debug.Log("Instancing a new BattleDatabase");
				GameObject go = Instantiate(Resources.Load ("Prefab/BattleDatabase")) as GameObject;
				go.name = "Battle Database";
			}
			return instance;
		}
	}

	public List<Battle> battleList = new List<Battle>();

	void Awake(){
		instance = this;
		buildBattleDatabase ();
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {

	}

	public void buildBattleDatabase(){

		List<BaseCharacter> demoParty = new List<BaseCharacter> ();
		//demoParty.Add (characterDatabase.getCharacterByName("Automaton"));
		//demoParty.Add (characterDatabase.getCharacterByName("Ashley"));

		demoParty.Add (CharacterDatabase.Instance.getCharacterByName("Automaton"));
		demoParty.Add (CharacterDatabase.Instance.getCharacterByName("Ashley"));

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
