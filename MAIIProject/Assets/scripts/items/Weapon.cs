using UnityEngine;
using System.Collections;

public class Weapon : StatItem {

	private int damage;
	private int delay;
	private bool twoHanded;
	public bool ranged;
	private WeaponTypes weaponType;

	public enum WeaponTypes {
		ATTACHMENT,
		GLOVE,
		DAGGER,
		SWORD,
		GREATSWORD,
		AXE,
		MACE,
		TOY,
		LANCE,
		SLINGSHOT,
		BOOMERANG,
		BOW,
		CROSSBOW,
		FLUTE,
		HARP,
		VIOLIN,
		WHIP,
		WAND,
		STAFF
	}

	public Weapon(string name, string display, int value, WeaponTypes wt, int dmg, int del){
		
		ItemName = name;
		DisplayName = display;
		
		itemType = ItemType.WEAPON;
		WeaponType = wt;
		
		itemValue = value;
		Damage = dmg;
		Delay = del;
		
		itemIcon = Resources.Load<Sprite> ("" + name);
		
		setWieldRequirements ();
	}

	public Weapon(string name, string display, int value, WeaponTypes wt, int dmg, int del,
	              int hpBoost, int mpBoost, int atkBoost, int defBoost, int accBoost, int evaBoost,
	              int spdBoost, int critRBoost, int critSBoost){

		ItemName = name;
		DisplayName = display;

		itemType = ItemType.WEAPON;
		WeaponType = wt;

		itemValue = value;
		Damage = dmg;
		Delay = del;

		MaxHPBoost = hpBoost;
		MaxMPBoost = mpBoost;
		AttackBoost = atkBoost;
		DefenseBoost = defBoost;
		AccuracyBoost = accBoost;
		EvasionBoost = evaBoost;
		SpeedBoost = spdBoost;
		CritRateBoost = critRBoost;
		CritStrengthBoost = critSBoost;

		itemIcon = Resources.Load<Sprite> ("" + name);

		setWieldRequirements ();
	}

	public Weapon (Weapon template){

		ItemName = template.ItemName;
		DisplayName = template.DisplayName;
		itemIcon = template.itemIcon;
		itemType = ItemType.WEAPON;
		weaponType = template.WeaponType;
		itemValue = template.itemValue;
		Damage = template.Damage;
		Delay = template.Delay;
		LevelReq = template.LevelReq;
		TwoHanded = template.TwoHanded;

		MaxHPBoost = template.MaxHPBoost;
		MaxMPBoost = template.MaxMPBoost;
		AttackBoost = template.AttackBoost;
		DefenseBoost = template.DefenseBoost;
		AccuracyBoost = template.AccuracyBoost;
		EvasionBoost = template.EvasionBoost;
		SpeedBoost = template.SpeedBoost;
		CritRateBoost = template.CritRateBoost;
		CritStrengthBoost = template.CritStrengthBoost;

		setWieldRequirements ();
	}

	public Weapon(){}

	private void setWieldRequirements (){

		if (WeaponType == WeaponTypes.GLOVE || WeaponType == WeaponTypes.GREATSWORD || WeaponType == WeaponTypes.LANCE || WeaponType == WeaponTypes.STAFF
		    || WeaponType == WeaponTypes.WHIP || WeaponType == WeaponTypes.WAND || WeaponType == WeaponTypes.TOY) {
			twoHanded = true;
		}
		if (WeaponType == WeaponTypes.BOOMERANG || WeaponType == WeaponTypes.BOW || WeaponType == WeaponTypes.CROSSBOW || WeaponType == WeaponTypes.FLUTE
		    || WeaponType == WeaponTypes.HARP || WeaponType == WeaponTypes.VIOLIN) {
			twoHanded = true;
			ranged = true;
		}
	}

	// setters and getters
	public WeaponTypes WeaponType {
		get{ return weaponType;}
		set{ weaponType = value;}
	}

	public int Damage {
		get{ return damage;}
		set{ damage = value;}
	}

	public int Delay {
		get{ return delay;}
		set{ delay = value;}
	}

	public bool TwoHanded {
		get{ return twoHanded;}
		set{ twoHanded = value;}
	}

}
