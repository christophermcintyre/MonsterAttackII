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

	private JobList jobList;
	public List<Action> actions = new List<Action> ();

	public int killCount;
	public int deathCount;
	public int currentHp;
	public int currentMp;
	public int actionGuage;

	public bool playerControl;

	public Action currentAction;



	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void initCharacter(){

		jobList = GetComponent<JobList> ();
		jobList.init ();
		name = firstName;
		actions.Add(new Attack (this));

		//equipmentSlots = new List<EquipmentSlot> ();
		//addEquipmentSlots ();
		revive (true);
	}

	public void update(){
		//Debug.Log (name+ "I'm updating");
		if(alive() && actionGuage < 1000){
			actionGuage += CurrentJob.Speed;
		}
		if (currentAction != null && ActionGuage >= currentAction.chargeTime ){
			currentAction.execute();
			currentAction = null;
		}
	}

	public bool ready(){
		return (actionGuage >= 1000);
	}

	public void performAction(List<BaseCharacter> targets){
		//Debug.Log (name+ ": I'm performing an action.");
		actions[0].beginCharging(getRandomEnemy(targets));
		reset ();

	}

	public void chooseAction(List<BaseCharacter> allies ,List<BaseCharacter> enemies){
		//Debug.Log (Name+ ": I'm performing an action.");
		if (this.playerControl) actions[0].beginCharging(getRandomEnemy(enemies));
		else actions[0].beginCharging(getRandomEnemy(allies));
		reset ();
		
	}

	public void attack(BaseCharacter target){
		actions [0].beginCharging (target);
		reset ();
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
		ActionGuage = 0;
	}

	public void resetAction(){
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

	public void evade(){
		}

	public void damage(BaseCharacter attacker, int dmg){

		if (dmg < 0) dmg = 0;
		Debug.Log (attacker.name + " strikes " + name + " for " + dmg + " damage." );
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
		this.GetComponent<Animation>().CrossFade("Idle");
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

	public int TotalCritRate(){
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
		set{ Debug.Log("Unable to set job through this method");}
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
