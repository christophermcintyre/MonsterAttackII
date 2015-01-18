using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {

	public BattleDatabase battleDatabase;
	public Battle battle;
	private Party playerParty;
	private Party aiParty;
	
	public List<BaseCharacter> combatants = new List<BaseCharacter>();
	public List<BaseCharacter> actionQueue = new List<BaseCharacter>();
	private BattleStates currentState;

	public Text[] characterNames;
	public Text[] characterStats;
	public Text[] characterMP;
	public Image[] atbGauges;
	bool started = false;

	public float counter;
	public float battleSpeed = 0.1f;


	public enum BattleStates {
		START, //load assets, combatants, pan camera, starting play animations
		IDLE, //charging atb gauges
		ACTION, //someone is performing an action, continue atb gauges but only one actor at a time
		LOSE, //play losing sequence
		WIN, //play winning animations, give out gold and exp etc.
		EXIT
	}

	public void load(Battle b){
		battle = b;
	}

	void Start() {

		counter = Time.fixedTime + battleSpeed;
		Debug.Log ("Battle start");

		//battle = Player.instance.battleDatabase.battleList [0];
		battle = Player.instance.battleDatabase.getBattleByName ("Goblin Attack");
		//battle = battleDatabase.battleList [0];

		playerParty = Player.playerParty;
		aiParty = battle.enemyParty;
		combatants.AddRange(playerParty.getMembers());
		combatants.AddRange(aiParty.getMembers());

		if (battle == null)	Debug.Log ("Error: No battle loaded");

		if (battle != null)	currentState = BattleStates.START;

	}

	void FixedUpdate(){
		if (Time.fixedTime >= counter) {
			update();
			counter = Time.fixedTime + battleSpeed;
		}
	}

	void update () {

		//Debug.Log ("Battle updating");

		displayCharacterStats ();

		switch(currentState){

		case BattleStates.START:

			started = true;
			//Debug.Log("Start State");

			foreach(BaseCharacter c in combatants){
				//Debug.Log(c.name);
				c.ActionGuage = (int) (Random.value * c.CurrentJob.Speed) * 10;
			}

			//starting cutscene

			currentState = BattleStates.IDLE;
			break;

		case BattleStates.IDLE:

			//Debug.Log("IDLE State");

			if (started) {
				if (!playerParty.alive ()) {
					currentState = BattleStates.LOSE;
				}
				if (!aiParty.alive ()) {
					currentState = BattleStates.WIN;
				}
			}

			//delta counter

			foreach(BaseCharacter c in combatants){
				c.update();
				if(c.ready()){
					c.chooseAction(combatants);
					//actionQueue.Add(c);
				}
			}

			if (actionQueue.Count > 0) currentState = BattleStates.ACTION;

			break;

		case BattleStates.ACTION:

			Debug.Log("ACTION State");

			foreach(BaseCharacter q in actionQueue){
				currentState = BattleStates.ACTION;
				q.chooseAction(combatants);
			}

			actionQueue.Clear();

			currentState = BattleStates.IDLE;

			break;

		case BattleStates.LOSE:
			//Debug.Log("LOSE State");
			playerParty.defeat();
			currentState = BattleStates.EXIT;
			break;

		case BattleStates.WIN:
			//Debug.Log("WIN State");
			playerParty.addMoney(battle.moneyValue);
			playerParty.addExp(battle.expValue, true);
			currentState = BattleStates.EXIT;
			break;

		case BattleStates.EXIT:
			//Debug.Log("EXIT State");
			combatants.Clear();
			aiParty.getMembers().Clear();
			aiParty = null;
			playerParty.reset();
			Application.LoadLevel("main");
			break;

		}
	}

	public void displayCharacterStats(){

		for (int i = 0; i < playerParty.getMembers().Count; i++) {

			atbGauges[i].fillAmount = playerParty.getMembers()[i].ActionGuage / 1000.0f;
			characterNames[i].text = playerParty.getMembers()[i].name;
			characterStats[i].text = playerParty.getMembers()[i].CurrentHp + "/" + playerParty.getMembers()[i].CurrentJob.MaxHP;
			characterMP[i].text = playerParty.getMembers()[i].CurrentMp + "/" + playerParty.getMembers()[i].CurrentJob.MaxMP;


		}
	}
}
