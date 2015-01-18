using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleDatabase : MonoBehaviour {

	public List<Battle> battleList = new List<Battle>();
	//public static List<Battle> battleList = new List<Battle>();
	//public static BattleDatabase instance;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {

		//Debug.Log("Starting BattleDatabase");

		buildBattleDatabase ();
	}

	public void buildBattleDatabase(){

		Party goblinParty = new Party (CharacterDatabase.instance.monsters, "Goblin Party");

		//battleList.Add (new Battle(rat))

		battleList.Add (new Battle(goblinParty, "Goblin Attack", "Three goblin brothers.", 200, 200));

	}

	public Battle getBattleByName(string name){

		foreach (Battle b in battleList) {
			if (b.battleName == name){
				return copyBattle(b);
			}
		}
		return null;
	}

	public Battle copyBattle(Battle template){
		//Party copy = new Party (template.enemyParty);
		return new Battle (new Party (template.enemyParty), template.battleName, template.battleDesc, template.moneyValue, template.expValue);
	}
}
