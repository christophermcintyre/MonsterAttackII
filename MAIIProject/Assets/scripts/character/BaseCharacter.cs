using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCharacter : MonoBehaviour{

	public string firstName;
	public string lastName;
	public Sprite portrait;

	public Weapon mainWeapon;
	public Weapon offHandWeapon;
	public Accessory accessory1;
	public Accessory accessory2;

	public JobList jobList;
	private List<Ability> innateAbilities = new List<Ability> ();
	private List<Ability> allAbilities = new List<Ability> ();

	public int killCount;
	public int deathCount;
	public int currentHp;
	public int currentMp;
	public int actionGuage;
	public int chargeCounter;

	public bool playerControl;

	public Ability currentAction;
	public BaseCharacter currentTarget;

	public string stealItem;
	public bool stealable = false;

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void initCharacter(){
		jobList = GetComponent<JobList> ();
		jobList.init ();
		name = firstName;
		innateAbilities.Add (new Attack (this));
		//actions.Add (new Bash (this));
		//actions.Add (new Cure (this));

		//equipmentSlots = new List<EquipmentSlot> ();
		//addEquipmentSlots ();
		revive (true);
	}

	public void update(){
		//Debug.Log (name+ "I'm updating");
		if(alive() && actionGuage < 1000){
			actionGuage += CurrentJob.Speed;
		}

		if (currentAction != null) {
			chargeCounter += CurrentJob.Speed;

			if (chargeCounter >= currentAction.chargeTime ){
				currentAction.execute();
			}
		}
	}

	public bool ready(){
		return (actionGuage >= 1000 && currentAction == null);
	}

	public void chooseRandomAction(List<BaseCharacter> allies, List<BaseCharacter> enemies){
		currentAction = Actions [(int)(Random.value * Actions.Count)];
		if (currentAction.targetType == Ability.TargetType.ENEMY_SINGLE) currentAction.beginCharging (getRandomEnemy (allies));
		else if (currentAction.targetType == Ability.TargetType.ALLY_SINGLE)	currentAction.beginCharging (getRandomEnemy (enemies));
	}

	//public void attack(BaseCharacter target){
	//	currentAction = actions [0];
	//	currentAction.beginCharging (target);
	//	Debug.Log (firstName + ": I'm using " + currentAction.executor.firstName + "'s " + currentAction.actionName + " on " + currentAction.target.firstName);
	//	this.GetComponent<Animation>().CrossFade("Battle_Idle");
	//}

	public void performAction(BaseCharacter target, Ability act){
		//currentAction = act;
		currentAction = Actions[Actions.IndexOf(act)];
		currentAction.beginCharging (target);

		this.GetComponent<Animation>().CrossFade("Battle_Idle");
	}

	public BaseCharacter getRandomEnemy(List<BaseCharacter> targets) {
		int r = (int) (Random.value * targets.Count);
		BaseCharacter selectedTarget = targets[r];
		return selectedTarget;
	}

	public void revive(bool fullRevive){
		if (!alive ()) {
			CurrentHp = 1;
		}

		if (fullRevive) {
			CurrentHp = jobList.getCurrentJob().MaxHP;
			CurrentMp = jobList.getCurrentJob().MaxMP;
		}
	}

	public void reset(){
		if (playerControl) this.GetComponent<Animation>().CrossFade("Idle");

		ActionGuage = 0;
		resetAction ();
	}

	public void resetAction(){
		chargeCounter = 0;
		currentAction = null;
	}

	//public void addJob(Job j){
	//	Debug.Log ("Adding job: " + j.Name + " to " + name);
	//	j.initJob (this);
		//JobsList.Add (j);
	//}

	/*public void addEquipmentSlots(){
		equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.RIGHTHAND, this));
		equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.LEFTHAND, this));
		equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY, this));
		equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY, this));

	}

	public void equip(StatItem item, EquipmentSlot slot){
		if (!item.Equals(slot.EquippedItem)){
			if (slot.EquippedItem != null) unequip(slot);
			if (item.equipped()) {
				Debug.Log("Already equipped on another slot");
			}else{
				slot.EquippedItem = item;
				item.onEquip(this);
			}
		} else unequip(slot);
	}

	public void unequip(StatItem item){
		foreach (EquipmentSlot es in equipmentSlots){
			if (es.EquippedItem != null && es.EquippedItem.Equals(item)) es.removeItem();
		}
	}

	public void unequip(EquipmentSlot slot){
		slot.EquippedItem.unequip();
		slot.removeItem();
	}*/

	public void evade(){}

	public void damage(BaseCharacter attacker, int dmg, Element e){

		if (dmg < 0) dmg = 0;

		CurrentHp -= dmg;
		if (CurrentHp <= 0) {
			CurrentHp = 0;
			Debug.Log(attacker.name + " has vanquished the " + name + "!");
			die();
		}
	}

	public void heal(int hp){
		if (alive()) {
			CurrentHp += hp;
			if (CurrentHp > CurrentJob.MaxHP) CurrentHp = CurrentJob.MaxHP;
		}
	}

	public void die(){
		CurrentHp = 0;
		reset ();
		deathCount++;
		this.gameObject.SetActive (false);
		//this.gameObject.GetComponent<MeshRenderer>
		//this.GetComponent<Animation>().CrossFade("Knockout");
	}

	public void addKill(){
		killCount++;
	}

	public bool alive(){return CurrentHp > 0;}


	public int TotalAttack(){
		return CurrentJob.Attack;
	}

	public int TotalDefense(){		
		return CurrentJob.Defense;
	}

	public int TotalAccuracy(){	
		return CurrentJob.Accuracy;
	}

	public int TotalEvasion(){	
		return CurrentJob.Evasion;
	}

	public float TotalCritRate(){
		return CurrentJob.CritRate;
	}

	public float TotalCritStrength(){
		return CurrentJob.CritStrength;
	}

	public Sprite Portrait{
		get{ return portrait;}
		set{ portrait = value;}
	}

	public string Name{
		get{ return firstName;}
		set{ firstName = value;}
	}



	public Job CurrentJob{
		get{ return jobList.getCurrentJob();}
		private set{ Debug.Log("Unable to set job through this method");}
	}

	public List<Ability> Actions {
		get{ 
			allAbilities.Clear();
			allAbilities.AddRange(innateAbilities);
			allAbilities.AddRange(CurrentJob.Actions);
			return allAbilities;}
		private set{ Debug.Log ("Error");}
	}

	public List<Ability> Skills {
		get{ return CurrentJob.Actions;}
		private set{ Debug.Log ("Error");}
	}

	//public List<Job> JobsList{
	//	get{ return jobsList;}
	//	set{ jobsList = value;}
	//}

	public int ActionGuage{
		get{ return actionGuage;}
		set{ actionGuage = value;}
	}

	public int CurrentHp{
		get{ return currentHp;}
		set{ currentHp = value;}
	}

	public int CurrentMp{
		get{ return currentMp;}
		set{ currentMp = value;}
	}
}
