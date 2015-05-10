using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ListBattle : MonoBehaviour, IPointerDownHandler {

	public Battle battle;
	public Text nameText;
	
	void Start () {
		
		//Debug.Log ("parent is: " + this.transform.parent);
		nameText = gameObject.transform.GetChild (1).GetComponent<Text>();
	}
	
	public void OnPointerDown(PointerEventData data) {
		if (data.button == PointerEventData.InputButton.Left) {
			
			GetComponentInParent<BattleListMenu>().selectedBattle = (Battle)battle;
			
			GetComponentInParent<BattleListMenu>().refresh();
			nameText.color = new Color (255, 255, 0);
		}
	}
	
	public void displayBattle(Battle b) {
		Start ();
		battle = b;
		nameText.text = b.battleName;
		//if (i.equipped())	nameText.color = new Color (0, 255, 0);
	}
}
