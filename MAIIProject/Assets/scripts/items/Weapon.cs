using UnityEngine;
using System.Collections;

public class Weapon : StatItem {

	private int damage;
	private int delay;
	private bool twoHanded;

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

	private WeaponTypes weaponType;



	public Weapon(string name, WeaponTypes wt, int dmg, int del){
		ItemName = name;
		weaponType = wt;
		Damage = dmg;
		Delay = del;
		}

	public Weapon(){}

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
