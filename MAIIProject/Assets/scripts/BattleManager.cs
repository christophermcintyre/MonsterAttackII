using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {

	//public Player player; //FIND THE PLAYER

	public BattleDatabase battleDatabase;
	public Battle battle;
	private List<BaseCharacter> playerParty;
	private List<BaseCharacter> aiParty;
	
	public List<BaseCharacter> combatants = new List<BaseCharacter>();
	public List<BaseCharacter> actionQueue = new List<BaseCharacter>();
	private BattleStates currentState;

	public Text[] characterNames;
	public Text[] characterStats;
	public Text[] characterMP;
	public Image[] atbGauges;

	public CommandMenu commandMenu;
	public GameObject commandMenuPanel;

	bool started = false;

	public float counter;
	public float battleSpeed = 0.1f;

	public List<Transform> playerPositions = new List<Transform> ();
	public List<Transform> enemyPositions = new List<Transform> ();

	//public BaseCharacter temp;

	public enum BattleStates {
		START, // pan camera, starting play animations
		IDLE, //charging atb gauges
		ACTION, //someone is performing an action, continue atb gauges but only one actor at a time
		LOSE, //play losing sequence
		WIN, //play winning animations, give out gold and exp etc.
		EXIT
	}

	void Awake(){
		//player = (Player)GameObject.FindWithTag("Player").GetComponent<Player>();
	}

	void Start(){
		//If the battle level is loaded without a battle set, default to training battle
		if (BattleDatabase.Instance.selectedBattle != null) {
			battle = BattleDatabase.Instance.selectedBattle;
		} else {
			Debug.Log("No battle selected. Loading default battle");
			battle = BattleDatabase.Instance.getBattleByName("Training Battle");
		}
		init();
	}

	void init() {
		//Debug.Log ("Initializing battle");
		commandMenuPanel.SetActive (false);
		counter = Time.fixedTime + battleSpeed;

		playerParty = Player.Instance.GetComponent<Player> ().playerParty;
		aiParty = new List<BaseCharacter> ();

		for(int i = 0; i < playerParty.Count ; i++){
			playerParty[i].transform.position = playerPositions[i].position;
			playerParty[i].transform.rotation = playerPositions[i].rotation;
		}

		for(int i = 0; i < battle.enemyParty.Count ; i++){
			aiParty.Add ((BaseCharacter)Instantiate(battle.enemyParty[i], enemyPositions[i].position, enemyPositions[i].rotation));
			aiParty[i].initCharacter();
		}

		combatants.AddRange(playerParty);
		combatants.AddRange(aiParty);

		foreach(BaseCharacter c in combatants){
			c.ActionGuage = (int) (Random.value * c.CurrentJob.Speed) * 10;
		}

		if (battle != null)	{
			//Debug.Log ("Initialization succesful. Starting battle.");
			started = true;
			currentState = BattleStates.START;
		} else {
			Debug.Log ("No battle loaded.");
			Application.LoadLevel("main");
		}

	}

	void FixedUpdate(){
		if (battle != null){
			displayCharacterStats ();
			if (Time.fixedTime >= counter) {
				update();
				counter = Time.fixedTime + battleSpeed;
			}
		}
	}

	void update () {

		switch(currentState){

		case BattleStates.START:
			//play opening event
			currentState = BattleStates.IDLE;
			break;

		case BattleStates.IDLE:

			//Debug.Log("IDLE State");

			if (started) {
				checkWinCondition();
				checkLoseCondition();
			}

			foreach(BaseCharacter c in combatants){
				c.update();
				if(c.ready()){
					if (c.playerControl) {
						if (!commandMenu.isActiveAndEnabled){
							openCommandMenu(c);
						}
					} else c.chooseRandomAction(playerParty, aiParty);
					//actionQueue.Add(c);
				}
			}
			//if (actionQueue.Count > 0) currentState = BattleStates.ACTION;
			break;

		case BattleStates.ACTION:

			Debug.Log("ACTION State");
			actionQueue.Clear();
			currentState = BattleStates.IDLE;
			break;

		case BattleStates.LOSE:
			//Debug.Log("LOSE State");
			Player.Instance.defeat();
			currentState = BattleStates.EXIT;
			break;

		case BattleStates.WIN:
			//Debug.Log("WIN State");
			Player.Instance.win();
			Player.Instance.addMoney(battle.moneyValue);
			Player.Instance.addExp(battle.expValue, true);
			currentState = BattleStates.EXIT;
			break;

		case BattleStates.EXIT:
			//Debug.Log("EXIT State");
			combatants.Clear();
			foreach (BaseCharacter bc in aiParty){
				Destroy(bc.gameObject);
			}
			aiParty.Clear();
			aiParty = null;
			foreach (BaseCharacter c in playerParty){
				c.reset();
			}

			Application.LoadLevel("main");
			break;

		}
	}

	public void checkWinCondition(){
		foreach (BaseCharacter c in aiParty){
			if (c.alive()) {
				//Do nothing, the enemy is still alive
				return;
			}
		}
		currentState = BattleStates.WIN;				
	}

	public void checkLoseCondition(){
		foreach (BaseCharacter c in playerParty){
			if (c.alive()) {
				//Do nothing, the player is still alive
				return;
			}
		}
		currentState = BattleStates.LOSE;		
	}

	public void displayCharacterStats(){

		for (int i = 0; i < playerParty.Count; i++) {

			atbGauges[i].fillAmount = playerParty[i].ActionGuage / 1000.0f;
			characterNames[i].text = playerParty[i].name;
			characterStats[i].text = playerParty[i].CurrentHp + "/" + playerParty[i].CurrentJob.MaxHP;
			characterMP[i].text = playerParty[i].CurrentMp + "/" + playerParty[i].CurrentJob.MaxMP;


		}
	}

	public void openCommandMenu(BaseCharacter bc){
		commandMenu.open (bc, combatants);
	}


	public void targetingMode(){

	}


}
