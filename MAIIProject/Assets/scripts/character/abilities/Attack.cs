using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack : Action {

	public Attack(BaseCharacter e){
		actionName = "Attack";
		elementalProperty = Element.BLUNT;
		targetType = TargetType.ENEMY_SINGLE;
		executor = e;
		chargeTime = 100;
	}

	public override void execute(){

		if (executor.mainWeapon != null) elementalProperty = executor.mainWeapon.elementalProperty;

		if (calculateHit(target, null)) {
			target.damage(executor, calculateDmg(target, executor.mainWeapon), elementalProperty);
		} 
			
		if (executor.offHandWeapon != null && calculateHit(target, null)) {
			target.damage(executor, calculateDmg(target, executor.offHandWeapon), elementalProperty);			
		}
	
		executor.reset();

	}
	
	public bool calculateHit(BaseCharacter target, Weapon w){
		double hitRate = 75 + (executor.TotalAccuracy() - target.TotalEvasion())*0.5;
		if (hitRate > 95) {hitRate = 95;}
		if (hitRate < 20) {hitRate = 20;}
		
		if ((Random.value*100) > hitRate) {
			target.evade();
			Debug.Log(executor.Name + " misses " + target.Name + ".");
			DamagePopUp.ShowMessage ("MISS", target.transform.position);
			return false;
		}
		return true;
	}
	
	public int calculateDmg(BaseCharacter target, Weapon w) {
		int dmg = (int)(Random.value * executor.TotalAttack ());

		//Debug.Log (executor.Name + "'s Total Attack: " + executor.TotalAttack() + " Damage Roll: " + dmg);

		if (w != null) dmg += w.Damage;
		
		if ((Random.value*100) <= executor.TotalCritRate()) {
			dmg=(int)(executor.TotalCritStrength()*dmg);
			Debug.Log("Critical hit! ");
		}
		dmg -= target.TotalDefense();
		if (dmg < 0) dmg = 0;
		Debug.Log (executor.name + " strikes " + target.name + " for " + dmg + " damage." );		
		DamagePopUp.ShowMessage ("" + dmg, target.transform.position);

		return dmg;
	}
}
