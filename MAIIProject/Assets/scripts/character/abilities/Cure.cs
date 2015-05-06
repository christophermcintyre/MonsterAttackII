﻿using UnityEngine;

public class Cure : Action {

	public int potency=50;

	public Cure(BaseCharacter e){
		actionName = "Cure";
		elementalProperty = Element.LIGHT;
		targetType = TargetType.ALLY_SINGLE;
		executor = e;
		chargeTime = 100;
	}
	
	public override void execute(){

		target.heal (potency);

		Debug.Log (executor.name + " heals " + target.name + " for " + potency + " health." );		
		DamagePopUp.ShowMessage ("" + potency, target.transform.position);

		executor.reset();
		
	}
}
