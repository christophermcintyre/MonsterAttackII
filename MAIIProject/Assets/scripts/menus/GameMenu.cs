using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameMenu : Menu {

	public List<BaseCharacter> partyList;
	public List<GameObject> partyMemberPanels;

	public Image[] portraits;
	public Text[] names;
	public Text[] jobs;
	public Text[] vitals;
	public Text[] weapons;

	public Text wins;
	public Text defeats;
	public Text money;

	//public string[] currency = new string[] {"Bank","Benjamins","Bills","Bones","Bread","Bucks","Cabbage","Cash","Cheddar","Chips","Clams","Coins","Dead Kings","Dosh","Dough","Funds","Funny money","Gravy","Green","Lettuce","Loot","Lucre","Moolah","Paper","Peanuts","Pennies","Scratch","Skrilla","Simoleons","Stash","Wads"};

	void Start () {
		foreach(GameObject go in partyMemberPanels){
			go.GetComponent<Button>().enabled = false;
		}
		partyList = Player.Instance.playerParty;
	}

	public override void open(){
		refresh ();
	}

	public override void close(){

	}

	public override void refresh(){
		foreach (BaseCharacter member in partyList) {		
			partyMemberPanels[partyList.IndexOf(member)].GetComponent<Button>().enabled = true;
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
		money.text = "Dosh: " + Player.Instance.Funds;
		wins.text = "Wins: " + Player.Instance.Wins;
		defeats.text = "Losses: " + Player.Instance.Defeats;
	}
}
