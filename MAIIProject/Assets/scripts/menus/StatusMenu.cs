using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	public void Start(){}

	public override void close(){
		for (int i = 0; i < slots.Length; i++) {
			slots[i].reset();
		}
	}

	public override void open(){
		refresh ();
	}

	public override void refresh(){
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
}
