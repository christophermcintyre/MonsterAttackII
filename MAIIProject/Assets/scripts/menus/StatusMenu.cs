using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StatusMenu : Menu {

	public Image portrait;

	public Slot[] slots;
	public Text characterName;
	public Text characterJob;

	public Text experience;
	public Text health;
	public Text mana;
	public Text attack;
	public Text defense;
	public Text accuracy;
	public Text evasion;

	public ListItem listItemPrefab;
	public GameObject jobListPanel;
	public List<ListItem> jobDisplayList = new List<ListItem>();
	//public ListItem selectedJob;


	public void Start(){}

	public override void close(){
		for (int i = 0; i < slots.Length; i++) {
			slots[i].reset();
		}
		closeJobsList ();
	}

	public void closeJobsList(){
		jobListPanel.SetActive (false);
		foreach (ListItem obj in jobDisplayList) {
			Destroy (obj.gameObject);
		}		
		jobDisplayList.Clear ();
	}

	public override void open(){
		refresh ();
		for (int i = 0; i < slots.Length; i++) {
			slots[i].refresh();
		}
	}

	public override void refresh(){

		if (jobListPanel.activeSelf){
			foreach (Job j in activeCharacter.jobList.jobs){
				ListItem l = (ListItem)Instantiate(listItemPrefab);
				jobDisplayList.Add(l);
				//l.displayItem(i);
				l.Start ();
				l.index = activeCharacter.jobList.jobs.IndexOf(j);
				l.nameText.text = (j.Level + " " + j.Name);
				l.transform.SetParent(jobListPanel.transform, false);
				l.parentMenu = this;
			}
		}

		if(activeCharacter.mainWeapon != null){
			slots[0].item = activeCharacter.mainWeapon;
		}
		
		if(activeCharacter.offHandWeapon != null){
			slots[1].item = activeCharacter.offHandWeapon;
		}
		
		if(activeCharacter.accessory1 != null){
			slots[2].item = activeCharacter.accessory1;
		}
		
		if(activeCharacter.accessory2 != null){
			slots[3].item = activeCharacter.accessory2;
		}
		
		portrait.color = new Color32(255, 255, 255, 255);
		portrait.sprite = activeCharacter.Portrait;
		
		characterName.text = activeCharacter.Name;
		characterJob.text = "LVL " + activeCharacter.CurrentJob.Level + " " + activeCharacter.CurrentJob.Name;
		
		experience.text = "EXP: " + activeCharacter.CurrentJob.CurrentExp + "/" + activeCharacter.CurrentJob.ExpToLevel;
		health.text = "HP:" + activeCharacter.CurrentHp + "/" + activeCharacter.CurrentJob.MaxHP;
		mana.text = "MP: " + activeCharacter.CurrentMp + "/" + activeCharacter.CurrentJob.MaxMP;
		attack.text = "Attack: " + activeCharacter.TotalAttack();
		defense.text = "Defense: " + activeCharacter.TotalDefense();
		accuracy.text = "Accuracy: " + activeCharacter.TotalAccuracy();
		evasion.text = "Evasion: " + activeCharacter.TotalEvasion();
	}

	public override void select(ListItem l){
		activeCharacter.jobList.changeJob (l.index);
		closeJobsList ();
		refresh ();
	}
}
