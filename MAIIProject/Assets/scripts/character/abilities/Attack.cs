using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack : Action {

	public Attack(BaseCharacter e){
		actionName = "Attack";
		executor = e;
		chargeTime = 100;
	}

	public override void execute(){
		List<Weapon> weapons = new List<Weapon>();
		if (executor == null) Debug.Log("Error: no executor assigned");
		if (executor.equipmentSlots == null) Debug.Log ("Error: No equipment slots");
		//Debug.Log (executor.name + " I have " + executor.equipmentSlots.Count + " equipment slots");
		for(int i = 0; i < executor.equipmentSlots.Count; i++){			
			if (executor.equipmentSlots[i].EquippedItem != null && executor.equipmentSlots[i].EquippedItem.itemType == Item.ItemType.WEAPON){
				weapons.Add((Weapon) executor.equipmentSlots[i].EquippedItem);				
			}
		}
		if(weapons.Count == 0){
			if (calculateHit(target, null)) target.damage(executor, calculateDmg(target, null));			
		} else {
			foreach (Weapon w in weapons){
				if(target.alive() && calculateHit(target, w)) target.damage(executor, calculateDmg(target, w));				
			}
		}
		//counter = 0;
		executor.resetAction();

	}
	
	public bool calculateHit(BaseCharacter target, Weapon w){
		double hitRate = 75 + (executor.TotalAccuracy() - target.TotalEvasion())*0.5;
		if (hitRate > 95) {hitRate = 95;}
		if (hitRate < 20) {hitRate = 20;}
		
		if ((Random.value*100) > hitRate) {
			target.evade();
			Debug.Log(executor.Name + " misses " + target.Name + ".");
			return false;
		}
		return true;
	}
	
	public int calculateDmg(BaseCharacter target, Weapon w) {
		int dmg = 0;
		if (w != null) dmg = w.Damage + (int)(Random.value * (w.Damage / 2)) + executor.TotalAttack();
		else dmg = (int) (Random.value * (executor.TotalAttack() / 2)) + executor.TotalAttack();
		
		if ((Random.value*100) <= executor.TotalCritRate()) {
			dmg=(int)(executor.TotalCritStrength()*dmg);
			Debug.Log("Critical hit! ");
		}
		dmg -= target.TotalDefense();
		return dmg;
	}

}
