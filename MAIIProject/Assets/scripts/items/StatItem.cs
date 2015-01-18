using UnityEngine;
using System.Collections;

//equipable items that can gain exp and level up

public class StatItem : Item {

	public BaseCharacter owner;
	private int level;
	private int maxLevel;

	private int currentExp; //experience towards next level
	public int expToLevel;
	private int totalExp;

	private int levelReq; //lvl requirement to equip

	//required class to equip

	//elemental type
	//material type

	//stat bonuses
	private int maxHPBoost;
	private int maxMPBoost;	
	private int speedBoost;
	private int atkBoost;
	private int defBoost;
	private int evaBoost;
	private int accBoost;
	private int critRateBoost;
	private float critStrengthBoost;

	//additional effects

	public void onEquip(BaseCharacter e){		
		owner = e;
		//Debug.Log(DisplayName + " Equipped.");
	}

	public void unequip(){
		owner.unequip(this);
		owner = null;
		//Debug.Log(DisplayName + " Unequipped.");
	}

	public bool equipped(){
		if (owner != null) return true;
		else return false;
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

	public int MaxHPBoost{
		get{ return maxHPBoost;}
		set{ maxHPBoost = value;}
	}

	public int MaxMPBoost{
		get{ return maxMPBoost;}
		set{ maxMPBoost = value;}
	}

	public int SpeedBoost{
		get{ return speedBoost;}
		set{ speedBoost = value;}
	}

	public int AttackBoost{
		get{ return atkBoost;}
		set{ atkBoost = value;}
	}

	public int DefenseBoost{
		get{ return defBoost;}
		set{ defBoost = value;}
	}

	public int AccuracyBoost{
		get{ return accBoost;}
		set{ accBoost = value;}
	}

	public int EvasionBoost{
		get{ return evaBoost;}
		set{ evaBoost = value;}
	}

	public int CritRateBoost{
		get{ return critRateBoost;}
		set{ critRateBoost = value;}
	}

	public float CritStrengthBoost{
		get{ return critStrengthBoost;}
		set{ critStrengthBoost = value;}
	}
}
