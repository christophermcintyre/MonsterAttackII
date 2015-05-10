using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BattleListMenu : Menu {

	public Battle selectedBattle;
	public ListBattle listBattlePrefab;
	public List<ListBattle> battleDisplayList;

	public ItemList battleListPanel;

	public Text battleName;
	public Text battleDesc;

	public override void open(){
		displayList (BattleDatabase.Instance.battleList);
		refresh ();
	}

	public override void close(){
		foreach (ListBattle obj in battleDisplayList) {
			Destroy (obj.gameObject);
		}		
		battleDisplayList.Clear ();
		selectedBattle = null;
		this.IsOpen = false;
	}

	public void displayList(List<Battle> battles){
		foreach (Battle b in battles) {
			ListBattle l = (ListBattle)Instantiate(listBattlePrefab);
			battleDisplayList.Add(l);
			l.displayBattle(b);
			l.transform.SetParent(battleListPanel.gameObject.transform, false);
		}
	}

	public override void refresh(){
		
		foreach (ListBattle obj in battleDisplayList) {
			obj.transform.GetChild (1).GetComponent<Text>().color = new Color(255,255,255);
		}
		
		if (selectedBattle == null) {
			selectedBattle = (Battle)battleDisplayList[0].battle;
		}
		
		if (selectedBattle != null) {
			
			battleName.text = selectedBattle.battleName;
			battleDesc.text = selectedBattle.battleDesc;				

		}
	}

	public void enterBattle(){
		BattleDatabase.Instance.selectedBattle = selectedBattle;
		Application.LoadLevel ("battle");

	}

}
