using UnityEngine;
using System.Collections;

public class Battle {

	public Party enemyParty;

	public string battleName;
	public string battleDesc;

	public int moneyValue;
	public int expValue;

	//battlefield model
	//music

	public Battle(Party enemies, string name, string desc, int money, int exp){

		enemyParty = enemies;
		battleName = name;
		battleDesc = desc;
		moneyValue = money;
		expValue = exp;

	}
}
