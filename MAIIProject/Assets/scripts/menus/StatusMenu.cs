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

	public void Start(){
		//clean ();

	}

	public override void close(){
		for (int i = 0; i < slots.Length; i++) {
			slots[i].reset();
		}
	}

	public override void open(){

		if(character.equipmentSlots[0].EquippedItem != null){
			slots[0].item = character.equipmentSlots[0].EquippedItem;
		}

		if(character.equipmentSlots[1].EquippedItem != null){
			slots[1].item = character.equipmentSlots[1].EquippedItem;
		}

		if(character.equipmentSlots[2].EquippedItem != null){
			slots[2].item = character.equipmentSlots[2].EquippedItem;
		}

		if(character.equipmentSlots[3].EquippedItem != null){
			slots[3].item = character.equipmentSlots[3].EquippedItem;
		}

		portrait.color = new Color32(255, 255, 255, 255);
		portrait.sprite = character.Portrait;

		characterName.text = character.Name;
		characterJob.text = "LVL " + character.CurrentJob.Level + " " + character.CurrentJob.Name;

		experience.text = "EXP: " + character.CurrentJob.CurrentExp + "/" + character.CurrentJob.ExpToLevel;
		health.text = "HP:" + character.CurrentHp + "/" + character.CurrentJob.MaxHP;
		mana.text = "MP: " + character.CurrentMp + "/" + character.CurrentJob.MaxMP;
		attack.text = "Attack: " + character.TotalAttack();
		defense.text = "Defense: " + character.TotalDefense();
		accuracy.text = "Accuracy: " + character.TotalAccuracy();
		evasion.text = "Evasion: " + character.TotalEvasion();

	}
}
