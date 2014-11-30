using UnityEngine;
using System.Collections;

public class Job
{

		public BaseCharacter owner;
		public string jobName;
		private int level;
		private int maxLevel;
		private int currentExp; //experience towards next level
		private int expToLevel;
		private int totalExp;
		private float levelModifier;
		private int maxHP;
		private int maxMP;
		private int speed;
		private int atk;
		private int def;
		private int eva;
		private int acc;
		private int critRate;
		private float critStrength;

		public Job ()
		{
				level = 1;
				maxLevel = 75;
				currentExp = 0;
				totalExp = 0;
				expToLevel = 100;
				levelModifier = 1.1f;
		}

		public void addExp (int xp)
		{
				if (level < maxLevel) {
						currentExp += xp;
						totalExp += xp;
						if (currentExp >= expToLevel) {
								currentExp -= expToLevel;
								levelUp ();
						}
				}
		}

		private int calculateExpToLevel ()
		{
				return (int)(expToLevel * levelModifier);
		}

		public void levelUp ()
		{
				expToLevel = calculateExpToLevel ();
				level++;
				owner.revive (true);
		}

	
#region setters and getters
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
#endregion
}

