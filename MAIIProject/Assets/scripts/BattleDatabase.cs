using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleDatabase : MonoBehaviour {

	//public CharacterDatabase characterDatabase;

	public Battle selectedBattle;

	private static BattleDatabase instance = null;

	public static BattleDatabase Instance {
		get {
			if (instance == null) {
				//Debug.Log("Instancing a new BattleDatabase");
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

		List<BaseCharacter> trainingParty = new List<BaseCharacter> ();
		trainingParty.Add (CharacterDatabase.Instance.getCharacterByName("Automaton"));
		trainingParty.Add (CharacterDatabase.Instance.getCharacterByName("Ashley"));

		List<BaseCharacter> trainingParty2 = new List<BaseCharacter> ();
		trainingParty2.Add (CharacterDatabase.Instance.getCharacterByName("Automaton"));
		trainingParty2.Add (CharacterDatabase.Instance.getCharacterByName("Automaton"));

		battleList.Add (new Battle(trainingParty, "Training Battle", "A training fight against an automaton", 200, 200));
		battleList.Add (new Battle(trainingParty2, "Test Battle", "A battle to demonstrate selecting different battles", 100, 100));
		battleList.Add (new Battle(trainingParty, "Epic Boss Battle", "So epic you can't even", 200, 200));

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
