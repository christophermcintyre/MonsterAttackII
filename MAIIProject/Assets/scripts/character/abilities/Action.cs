﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Action {

	public string actionName;
	public string actionVerb;
	public BaseCharacter executor;
	public BaseCharacter target;

	public Element elementalProperty;
	public TargetType targetType;

	public int counter = 0;
	public int chargeTime = 100;
	public bool enabled = true;

	public enum TargetType
	{
		SELF_ONLY,
		ALLY_SINGLE,
		ALLY_GROUP,
		ALLY_OPTIONAL,
		ENEMY_SINGLE,
		ENEMY_GROUP,
		ENEMY_OPTIONAL

	}

	public virtual List<BaseCharacter> getValidTargets(){
		return null;
	}

	public void beginCharging(BaseCharacter t){
		target = t;
		//execute();
	}

	public void update (){

	}

	public void switchTarget(BaseCharacter t){
		target = t;
	}

	public virtual void execute(){

	}

}
