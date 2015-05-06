using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameMenu : Menu {

	public List<BaseCharacter> partyList;

	public Image[] portraits;
	public Text[] names;
	public Text[] jobs;
	public Text[] vitals;
	public Text[] weapons;


	void Start () {

		//reset ();	
	}

	public override void open(){

		//Debug.Log ("Updating character menu layout");
		partyList = Player.Instance.playerParty;


		foreach (BaseCharacter member in partyList) {		

			portraits[partyList.IndexOf(member)].color = new Color32(255, 255, 255, 255);
			portraits[partyList.IndexOf(member)].sprite = member.Portrait;
			names[partyList.IndexOf(member)].text = member.Name;
			jobs[partyList.IndexOf(member)].text = "LVL " + member.CurrentJob.Level + " " + member.CurrentJob.Name;
			vitals[partyList.IndexOf(member)].text = "HP " + member.CurrentHp + "/" + member.CurrentJob.MaxHP;
			if (member.mainWeapon != null) {
				weapons[partyList.IndexOf(member)].text = member.mainWeapon.DisplayName;
			} else { weapons[partyList.IndexOf(member)].text = "Unarmed";
			}
		}
	}

	public void enterBattle(){
		//BattleManager.load (new Battle());
		Application.LoadLevel ("battle");
	}

	public void selectCharacter(){

	}

	public void swapCharacter(){

	}

}
