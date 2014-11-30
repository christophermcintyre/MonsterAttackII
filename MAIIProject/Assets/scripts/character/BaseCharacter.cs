using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCharacter {

	private string characterName;

	private int killCount;
	private int deathCount;

	private int currentHp;
	private int currentMp;

	private int actionGuage;

	private Job currentJob;
	private List<Job> jobsList;

	public List<EquipmentSlot> equipmentSlots = new List<EquipmentSlot> ();

	public BaseCharacter(string name, Job job){
		characterName = name;
		CurrentJob = job;
		job.owner = this;
		jobsList.Add (job);
	}

	public void update(){
		//updateEffects ();
		if(alive() && actionGuage < 1000){
			actionGuage += currentJob.Speed;
		}
	}

	public bool ready(){
		return (actionGuage > 1000);
	}

	public void performAction(){

	}

	public void revive(bool fullRevive){

		if (!alive ()) {
			currentHp = 1;
		}

		if (fullRevive) {
			currentHp = currentJob.MaxHP;
			currentMp = currentJob.MaxMP;
		}

	}

	public void reset(){
		ActionGuage = 0;
	}


	public bool alive(){return currentHp > 0;}


	public string CharacterName{
		get{ return characterName;}
		set{ characterName = value;}
	}

	public Job CurrentJob{
		get{ return currentJob;}
		set{ currentJob = value;}
	}

	public List<Job> JobsList{
		get{ return jobsList;}
		set{ jobsList = value;}
	}

	public int ActionGuage{
		get{ return actionGuage;}
		set{ actionGuage = value;}
	}

	public int CurrentHp{
		get{ return currentHp;}
		set{ currentHp = value;}
	}

	public int CurrentMp{
		get{ return currentMp;}
		set{ currentMp = value;}
	}
}
