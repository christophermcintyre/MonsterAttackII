using UnityEngine;
using System.Collections;

public class AttributeDatabase {

	public int jobID;
	public static int maxLVL = 99;
		
	private int[] expToLevel = new int[maxLVL];
	private int[] maxHP = new int[maxLVL];
	private int[] maxMP = new int[maxLVL];		
	private int[] attack = new int[maxLVL];
	private int[] defense = new int[maxLVL];
	private int[] accuracy = new int[maxLVL];
	private int[] evasion = new int[maxLVL];
	private int[] speed = new int[maxLVL];

	//private int[] STR;
	//private int[] VIT;
	//private int[] DEX;
	//private int[] AGI;
	//private int[] INT;
	//private int[] MND;
	//private int[] CHR;
	//private int[] WSKILL;

	public AttributeDatabase(int jobID, int HP0, int HP1, int MP0, int MP1, int ATK0, int ATK1, int DEF0, int DEF1, int ACC0, int ACC1, int EVA0, int EVA1, int SPD0, int SPD1){
		//this.jobID = jobID;

		maxHP = Lerp(HP0, HP1);
		maxMP = Lerp(MP0, MP1);
		attack = Lerp(ATK0, ATK1);
		defense = Lerp(DEF0, DEF1);
		accuracy = Lerp(ACC0, ACC1);
		evasion = Lerp(EVA0, EVA1);
		speed = Lerp(SPD0, SPD1);
		expToLevel = Lerp(100, 10000);

	}
		
	private int[] Lerp(int start, int end){
		int[] num = new int[maxLVL];
		int x, y;
		int x0 = 1;
		int x1 = maxLVL;	
		for(x = 1; x <= x1; x++){
			y = start + ((((x-x0)*end)-((x-x0)*start)) / (x1-x0));
			num[x-1] = y;
			//System.out.println(y);
		}

		return num;

	}

	public int ExpToLevel(int lvl){
		int i = expToLevel[lvl];
		return i;
	}
	public int MaxHP(int lvl){		
		int i = maxHP[lvl];
		return i;
	}
	public int MaxMP(int lvl){
		int i = maxMP[lvl];
		return i;
	}

	public int Attack(int lvl){
		int i = attack[lvl];
		return i;
	}
	public int Defense(int lvl){
		int i = defense[lvl];
		return i;
	}
	public int Accuracy(int lvl){
		int i = accuracy[lvl];
		return i;
	}
	public int Evasion(int lvl){
		int i = evasion[lvl];
		return i;
	}
	public int Speed(int lvl){
		int i = speed[lvl];
		return i;
	}

}

