using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Action {

	public string actionName;
	public BaseCharacter executor;
	public BaseCharacter target;
	public int counter = 0;
	public int chargeTime = 100;
	public bool enabled = true;


	public virtual List<BaseCharacter> getValidTargets(){
		return null;
	}

	public void beginCharging(BaseCharacter t){
		target = t;
		execute();
	}

	public void update (){

	}

	public void switchTarget(BaseCharacter t){
		target = t;
	}

	public virtual void execute(){

	}

}
