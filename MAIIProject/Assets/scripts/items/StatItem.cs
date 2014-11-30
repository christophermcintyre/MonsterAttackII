using UnityEngine;
using System.Collections;

//equipable items that can gain exp and level up

public class StatItem : Item {

	private int level;
	private int maxLevel;

	private int currentExp; //experience towards next level
	private int totalExp;

	private int levelReq; //lvl requirement to equip

	//required class to equip

	//elemental type
	//material type

	//stat bonuses
	private int maxHP;
	private int maxMP;	
	private int speed;
	private int atk;
	private int def;
	private int eva;
	private int acc;
	private int critRate;
	private float critStrength;

	//additional effects

	public void setRequiredLevel(int lvl){
		levelReq = lvl;
	}

	//setters and getters
	public int Level{
		get{ return level;}
		set{ level = value;}
	}
	
	public int MaxLevel{
		get{ return maxLevel;}
		set{ maxLevel = value;}
	}

	public int CurrentExp{
		get{ return currentExp;}
		set{ currentExp = value;}
	}

	public int TotalExp{
		get{ return totalExp;}
		set{ totalExp = value;}
	}

	public int LevelReq{
		get{ return levelReq;}
		set{ levelReq = value;}
	}

	public int MaxHP{
		get{ return maxHP;}
		set{ maxHP = value;}
	}

	public int MaxMP{
		get{ return maxMP;}
		set{ maxMP = value;}
	}

	public int Speed{
		get{ return speed;}
		set{ speed = value;}
	}

	public int Attack{
		get{ return atk;}
		set{ atk = value;}
	}

	public int Defense{
		get{ return def;}
		set{ def = value;}
	}

	public int Accuracy{
		get{ return acc;}
		set{ acc = value;}
	}

	public int Evasion{
		get{ return eva;}
		set{ eva = value;}
	}

	public int CritRate{
		get{ return critRate;}
		set{ critRate = value;}
	}

	public float CritStrength{
		get{ return critStrength;}
		set{ critStrength = value;}
	}
}
