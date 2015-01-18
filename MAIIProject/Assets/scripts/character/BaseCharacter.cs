using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCharacter {

	public string name;
	public Sprite portrait;
	public Party party;
	private Job currentJob;
	private List<Job> jobsList = new List<Job>();
	public List<EquipmentSlot> equipmentSlots = new List<EquipmentSlot> ();
	public int killCount;
	public int deathCount;
	private int currentHp;
	private int currentMp;
	private int actionGuage;
	public bool playerControl;

	public Action currentAction;

	public BaseCharacter(string nName, Job job){
		name = nName;
		addEquipmentSlots ();
		addJob (job);
		CurrentJob = job;
		revive (true);
	}

	public BaseCharacter(BaseCharacter template){
		name = template.name;
		addEquipmentSlots ();
		addJob (template.currentJob);
		CurrentJob = jobsList[0];
		revive (true);

		for(int i = 0; i < template.equipmentSlots.Count; i++){
			if(template.equipmentSlots[i].EquippedItem != null){
				equip ((StatItem)ItemDatabase.instance.getItemByName(template.equipmentSlots[i].EquippedItem.itemName), equipmentSlots[i]);
			}
		}
	}

	public void update(){
		//Debug.Log (name+ "I'm updating");

		//updateEffects ();
		if(alive() && actionGuage < 1000){
			actionGuage += currentJob.Speed;
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
		CurrentJob.actions[0].beginCharging(getRandomEnemy(targets));


		reset ();

	}

	public void chooseAction(List<BaseCharacter> targets){
		//Debug.Log (name+ ": I'm performing an action.");
		CurrentJob.actions[0].beginCharging(getRandomEnemy(targets));
		reset ();
		
	}

	public BaseCharacter getRandomEnemy(List<BaseCharacter> targets) {
		List<BaseCharacter> enemies = new List<BaseCharacter> ();
		foreach(BaseCharacter bc in targets){
			if(bc.party != this.party){
				enemies.Add(bc);
			}
		}
		int r = (int) (Random.value * enemies.Count);
		BaseCharacter selectedTarget = enemies[r];
		return selectedTarget;
	}

	//public List<BaseCharacter> findEnemies(List<BaseCharacter> actives){
	//	List<BaseCharacter> enemies = new List<BaseCharacter> ();
	//	foreach(BaseCharacter bc in actives){
	//		if(bc.party != this.party){
	//			enemies.Add(bc);
	//		}
	//	}
	//	return enemies;
	//}

	public void revive(bool fullRevive){
		if (!alive ()) {
			currentHp = 1;
		}

		if (fullRevive) {
			currentHp = currentJob.MaxHP;
			currentMp = currentJob.MaxMP;
		}
	}

	public void reset(){
		ActionGuage = 0;
	}

	public void resetAction(){
	}

	public void addJob(Job j){
		j.initJob (this);
		JobsList.Add (j);
	}

	public void addEquipmentSlots(){
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
	}

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
	}

	public void addKill(){
		killCount++;
	}

	public bool alive(){return currentHp > 0;}


	public int TotalAttack(){
		int total = 0;
		foreach(EquipmentSlot es in equipmentSlots){
			if (es.EquippedItem != null){
				total += es.EquippedItem.AttackBoost;
			}
		}
		return total + currentJob.Attack;
	}

	public int TotalDefense(){		
		int total = 0;		
		foreach(EquipmentSlot es in equipmentSlots){
			if (es.EquippedItem != null){
				total += es.EquippedItem.DefenseBoost;
				if (es.EquippedItem.itemType == Item.ItemType.ACCESSORY){
					Accessory acc = (Accessory)es.EquippedItem;
					total += acc.Armor;
				}
			}
		}		
		return total + currentJob.Attack;
	}


	public int TotalAccuracy(){		
		int total = 0;		
		foreach(EquipmentSlot es in equipmentSlots){
			if (es.EquippedItem != null){
				total += es.EquippedItem.AccuracyBoost;
			}
		}		
		return total + currentJob.Accuracy;
	}

	public int TotalEvasion(){		
		int total = 0;		
		foreach(EquipmentSlot es in equipmentSlots){
			if (es.EquippedItem != null){
				total += es.EquippedItem.EvasionBoost;
			}
		}		
		return total + currentJob.Evasion;
	}

	public int TotalCritRate(){
		return currentJob.CritRate;
	}

	public float TotalCritStrength(){
		return currentJob.CritStrength;
	}

	public Sprite Portrait{
		get{ return portrait;}
		set{ portrait = value;}
	}

	public string Name{
		get{ return name;}
		set{ name = value;}
	}

	public Job CurrentJob{
		get{ return currentJob;}
		set{ currentJob = value;}
	}

	public List<Job> JobsList{
		get{ return jobsList;}
		set{ jobsList = value;}
	}

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
