using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Job{

	public BaseCharacter owner;

	public Job currentJob;

	private int jobID;
	private string name;
	private int level = 1;
	private int maxLevel = 15;
	private int currentExp = 0; //experience towards next level
	private int expToLevel = 100;
	private int totalExp = 0;
	private float levelModifier = 1.1f;
	private int maxHP=1;
	private int maxMP=1;
	private int speed=15;
	private int atk=10;
	private int def=10;
	private int eva=10;
	private int acc=10;
	private int critRate;
	private float critStrength;

	public List<Action> actions = new List<Action>();

	public Job () {
		actions.Add (new Attack(owner));
	}

	public void initJob(BaseCharacter bc){		
		owner = bc;
		actions.Add (new Attack(bc));
	}

	public void addExp (int xp)	{
		if (level < maxLevel) {
			currentExp += xp;
			totalExp += xp;
			if (currentExp >= expToLevel) {
				currentExp -= expToLevel;
				levelUp ();
			}
		}
	}

	public void levelUp () {
		expToLevel = (int)(expToLevel * levelModifier);
		level++;
		//owner.revive (true);
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
		get{ return level;}
		set{ level = value;}
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
	
	public int TotalExp {
		get{ return totalExp;}
		set{ totalExp = value;}
	}
	
	public int MaxHP {
		get{ return maxHP;}
		set{ maxHP = value;}
	}
	
	public int MaxMP {
		get{ return maxMP;}
		set{ maxMP = value;}
	}
	
	public int Speed {
		get{ return speed;}
		set{ speed = value;}
	}
	
	public int Attack {
		get{ return atk;}
		set{ atk = value;}
	}
	
	public int Defense {
		get{ return def;}
		set{ def = value;}
	}
	
	public int Accuracy {
		get{ return acc;}
		set{ acc = value;}
	}
	
	public int Evasion {
		get{ return eva;}
		set{ eva = value;}
	}
	
	public int CritRate {
		get{ return critRate;}
		set{ critRate = value;}
	}
	
	public float CritStrength {
		get{ return critStrength;}
		set{ critStrength = value;}
	}

}

