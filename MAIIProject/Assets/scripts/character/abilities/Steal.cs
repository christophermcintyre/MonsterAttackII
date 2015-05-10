using UnityEngine;
using System.Collections;

public class Steal : Action {

	public Steal (BaseCharacter e){
		actionName = "Steal";
		actionVerb = "steals from";
		elementalProperty = Element.WIND;
		targetType = TargetType.ENEMY_SINGLE;
		executor = e;
		chargeTime = 100;
	}

	public override void execute(){

		if (target.stealable){
			Player.Instance.inventory.add(ItemDatabase.Instance.getItemByName(target.stealItem));
			target.stealable = false;
			Debug.Log(executor.Name + " " + actionVerb + " " + target.Name);
			DamagePopUp.ShowMessage ("Stole " + target.stealItem + "!" , target.transform.position);

		} else DamagePopUp.ShowMessage ("Nothing to steal!", target.transform.position);

		executor.reset();
	}
}
