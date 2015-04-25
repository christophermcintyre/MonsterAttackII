using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {

	public GameObject player; //FIND THE PLAYER

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

	public CommandMenu commandMenu;
	public GameObject commandMenuPanel;

	bool started = false;

	public float counter;
	public float battleSpeed = 0.1f;

	//change to list of vectors??
	public List<Transform> playerPositions = new List<Transform> ();
	public List<Transform> enemyPositions = new List<Transform> ();

	//public BaseCharacter temp;

	public enum BattleStates {
		START, //load assets, combatants, pan camera, starting play animations
		IDLE, //charging atb gauges
		ACTION, //someone is performing an action, continue atb gauges but only one actor at a time
		LOSE, //play losing sequence
		WIN, //play winning animations, give out gold and exp etc.
		EXIT
	}

	public void load(Battle b){
		Debug.Log ("This probably does nothing");
		//battle = b;
	}

	void Start() {

		//player = (Player)FindObjectOfType (typeof(Player));
		player = GameObject.FindWithTag("Player");
		battleDatabase = player.GetComponent<Player> ().battleDatabase;
		//player = go.GetComponent<Player> ();

		commandMenuPanel.SetActive (false);
		counter = Time.fixedTime + battleSpeed;
		Debug.Log ("Battle start");


		//battle = Player.instance.battleDatabase.battleList [0];
		battle = battleDatabase.getBattleByName ("Training Battle");
		//battle = battleDatabase.battleList [0];

		playerParty = player.GetComponent<Player> ().playerParty;
		aiParty = battle.enemyParty;
		combatants.AddRange(playerParty.getMembers());
		combatants.AddRange(aiParty.getMembers());

		for(int i = 0; i < playerParty.getMembers().Count ; i++){
			Debug.Log("Moving into position: " + playerParty.getMembers()[i].Name);
			playerParty.getMembers()[i].transform.position = playerPositions[i].position;
		}

		for(int i = 0; i < aiParty.getMembers().Count ; i++){
				Debug.Log("Moving into position: " + aiParty.getMembers()[i].Name);
				aiParty.getMembers()[i].transform.position = enemyPositions[i].position;
		}



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
					if (c.playerControl) {
						openCommandMenu(c);
					} else c.chooseAction(combatants);
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

	public void openCommandMenu(BaseCharacter bc){

		commandMenu.open (bc, combatants);
		commandMenuPanel.SetActive (true);

	}


	public void targetingMode(){

	}


}
