using UnityEngine;
using System.Collections;

public class Bash : Ability {

	public Bash(BaseCharacter e){
		abilityName = "Bash";
		abilityVerb = "bashes";
		elementalProperty = Element.BLUNT;
		targetType = TargetType.ENEMY_SINGLE;
		executor = e;
		chargeTime = 100;
	}

	public override void execute(){
		if (calculateHit(target)) {
			target.damage(executor, calculateDmg(target, executor.mainWeapon), elementalProperty);
			target.resetAction();
		}
		executor.reset();
	}

	public bool calculateHit(BaseCharacter target){
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
		
		if (w != null) dmg += w.Damage;
		
		if ((Random.value*100) <= executor.TotalCritRate()) {
			dmg=(int)(executor.TotalCritStrength()*dmg);
			Debug.Log("Critical hit! ");
		}
		dmg -= target.TotalDefense();
		dmg = (int)(dmg * 0.25f);
		if (dmg < 0) dmg = 0;
		Debug.Log (executor.name + " " + abilityVerb + " " + target.name + " for " + dmg + " damage." );		
		DamagePopUp.ShowMessage ("" + dmg, target.transform.position);
		DamagePopUp.ShowMessage ("STUN", target.transform.position);

		return dmg;
	}
	public bool calculateStun(){
		return true;
	}
}
