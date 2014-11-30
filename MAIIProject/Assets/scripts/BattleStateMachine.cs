using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleStateMachine : MonoBehaviour {

	public enum BattleStates {
		START, //load assets, combatants, pan camera, starting play animations
		IDLE, //charging atb gauges
		ACTION, //someone is performing an action, continue atb gauges but only one actor at a time
		LOSE, //play losing sequence
		WIN, //play winning animations, give out gold and exp etc.
		EXIT
	}

	private BattleStates currentState;

	private Party playerParty;
	private Party aiParty;

	public List<BaseCharacter> combatants = new List<BaseCharacter>();
	public List<BaseCharacter> actionQueue = new List<BaseCharacter>();

	void Start() {
		currentState = BattleStates.START;
	}

	void update () {

		switch(currentState){

		case BattleStates.START:

			//init

			//load battle scene
			//load monsters
			playerParty = Player.playerParty;
			combatants.AddRange(playerParty.getMembers());
			combatants.AddRange(aiParty.getMembers());

			foreach(BaseCharacter c in combatants){
				c.ActionGuage = (int) (Random.value * c.CurrentJob.Speed) * 10;
			}
			//(random * luck) * speed

			//starting cutscene

			currentState = BattleStates.IDLE;
			break;

		case BattleStates.IDLE:
			//delta counter

			foreach(BaseCharacter c in combatants){
				c.update();
				if(c.ready()){
					actionQueue.Add(c);
				}
			}

			if (actionQueue.Count > 0) currentState = BattleStates.ACTION;

			break;

		case BattleStates.ACTION:

			foreach(BaseCharacter q in actionQueue){
				currentState = BattleStates.ACTION;
				q.performAction();
			}

			actionQueue.Clear();

			currentState = BattleStates.IDLE;

			break;

		case BattleStates.LOSE:
			playerParty.defeat();
			currentState = BattleStates.EXIT;
			break;

		case BattleStates.WIN:
			//playerParty.addMoney(battle.money);
			//playerParty.addExp(battle.exp);
			currentState = BattleStates.EXIT;
			break;

		case BattleStates.EXIT:
			combatants.Clear();
			aiParty.getMembers().Clear();
			aiParty = null;
			playerParty.reset();
			break;

		}

	}

}
