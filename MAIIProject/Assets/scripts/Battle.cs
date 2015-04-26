using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Battle{

	public List<BaseCharacter> enemyParty;

	public string battleName;
	public string battleDesc;

	public int moneyValue;
	public int expValue;

	//battlefield model
	//music

	public Battle(List<BaseCharacter> enemies, string name, string desc, int money, int exp){

		enemyParty = enemies;
		battleName = name;
		battleDesc = desc;
		moneyValue = money;
		expValue = exp;

	}
}
