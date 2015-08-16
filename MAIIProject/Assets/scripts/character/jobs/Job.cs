using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Job{

	public BaseCharacter owner;

	public Job currentJob;

	private int jobID;
	private string name;
	private int currentLevel = 0;
	private int maxLevel = 15;
	private int currentExp = 0; //experience towards next level
	private int expToLevel = 100;
	private int totalExp = 0;
	private float levelModifier = 1.1f;

	public AttributeDatabase attributes;

	private int maxHP=100;
	private int maxMP=10;
	private int speed=15;
	private int atk=10;
	private int def=10;
	private int eva=10;
	private int acc=10;
	private float critRate;
	private float critStrength;

	public List<Ability> actions = new List<Ability>();

	public Job () {
	}

	public void addExp (int xp)	{
		if (currentLevel < maxLevel) {
			currentExp += xp;
			totalExp += xp;
			if (currentExp >= expToLevel) {
				currentExp -= expToLevel;
				levelUp ();
			}
		}
	}

	public void levelUp () {
		ExpToLevel = (int)(ExpToLevel * LevelModifier);
		Level++;
				
		foreach (Ability a in actions) {
			if (Level >= a.RequiredLevel){
				a.enabled = true;
			}
		}
	}

	public List<Ability> Actions{
		get{ return actions;}
		set{ actions = value;}
	}

	public string Name {
		get{ return name;}
		set{ name = value;}
	}

	public int JobID {
		get{ return jobID;}
		set{ jobID = value;}
	}

	public int Level {
		get{ return currentLevel;}
		set{ currentLevel = value;}
	}
	
	public int MaxLevel {
		get{ return maxLevel;}
		set{ maxLevel = value;}
	}
	
	public int CurrentExp {
		get{ return currentExp;}
		set{ currentExp = value;}
	}

	public int ExpToLevel {
		get{ return expToLevel;}
		set{ expToLevel = value;}
	}

	public float LevelModifier {
		get { return levelModifier;	}
	}
	
	public int TotalExp {
		get{ return totalExp;}
		set{ totalExp = value;}
	}
	
	public int MaxHP {
		get{ return attributes.MaxHP(Level);}
		private set{ maxHP = value;}
	}
	
	public int MaxMP {
		get{ return attributes.MaxMP(Level);}
		set{ maxMP = value;}
	}
	
	public int Speed {
		get{ return attributes.Speed(Level);}
		set{ speed = value;}
	}
	
	public int Attack {
		get{ return attributes.Attack(Level);}
		set{ atk = value;}
	}
	
	public int Defense {
		get{ return attributes.Defense(Level);}
		set{ def = value;}
	}
	
	public int Accuracy {
		get{ return attributes.Accuracy(Level);}
		set{ acc = value;}
	}
	
	public int Evasion {
		get{ return attributes.Accuracy(Level);}
		set{ eva = value;}
	}
	
	public float CritRate {
		get{ return critRate;}
		set{ critRate = value;}
	}
	
	public float CritStrength {
		get{ return critStrength;}
		set{ critStrength = value;}
	}

}

