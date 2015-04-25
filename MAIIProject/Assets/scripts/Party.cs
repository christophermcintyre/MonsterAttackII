using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Party {

	private List<BaseCharacter> members = new List<BaseCharacter> ();
	public string name;
	public Inventory inventory;
	private int funds;
	private int wins;
	private int defeats;

	public Party(string nName){
		name = nName;
		inventory = new Inventory (this);
	}

	public Party(List<BaseCharacter> list, string nName){
		name = nName;
		addMembers (list);
	}

	public Party(Party template){

		name = template.name;
		inventory = new Inventory (this);

		foreach (BaseCharacter bc in template.getMembers()) {
			//members.Add(CharacterDatabase.instance.getCharacterByName(bc.Name));
		}
	}

	public void addMember(BaseCharacter c){
		//check party size limit
		c.party = this;
		members.Add (c);
		//c.setParty (this);

	}

	public bool alive(){
		foreach (BaseCharacter c in members){
			if (c.alive()) {
				return true;
			}
		}
		return false;
	}

	public void addMembers(List<BaseCharacter> characters){
		foreach(BaseCharacter c in characters){
			//Debug.Log("Adding " + c.Name);
			c.party = this;
			members.Add (c);
			//c.setParty(this);
		}		
	}

	public List<BaseCharacter> getMembers(){
		return members;
	}

	public void win(){
		wins++;
	}

	public void defeat(){
		defeats++;
		removeMoney((int) (0.1 * funds));
		revive ();
	}

	public void revive(){
		foreach(BaseCharacter c in members){
			c.revive(false);

		}
	}

	public void reset(){
		foreach(BaseCharacter c in members){
			c.reset();
		}
	}

	public void addExp(int xp, bool shareDead){

		if(shareDead) {
			foreach(BaseCharacter c in members){
				c.CurrentJob.addExp(xp / members.Count);
				//c.addEquipmentEXP(xp / members.Count);
			}

		} else {
			int livePartySize = 0;
			foreach(BaseCharacter c in members){
				if (c.alive()){
					livePartySize++;
				}
			}

			int sharedEXP = (xp / livePartySize);
			foreach(BaseCharacter c in members){
				if (c.alive()){
					c.CurrentJob.addExp(sharedEXP);
					//c.addEquipmentEXP(sharedEXP);
				}
			}
		}
	}

	public void addMoney(int f){
		funds += f;
	}

	public void removeMoney(int f){
		funds -= f;
		if (funds < 0)	funds = 0;
	}

}
