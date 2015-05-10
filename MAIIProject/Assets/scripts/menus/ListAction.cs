using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ListAction : MonoBehaviour, IPointerDownHandler {

	public Action action;
	public CommandMenu parentMenu;

	public Image iconImage;
	public Text nameText;

	public void Start(){
		iconImage = gameObject.transform.GetChild (0).GetComponent<Image>();
		nameText = gameObject.transform.GetChild (1).GetComponent<Text>();
	}

	public void OnPointerDown(PointerEventData data) {
		if (data.button == PointerEventData.InputButton.Left) {
			parentMenu.selectedAction = action;
			parentMenu.openTargetMenu();
			//nameText.color = new Color (255, 255, 0);
		}
	}
	
	public void displayAction(Action a){
		Start ();
		action = a;
		nameText.text = a.actionName;
	}

}
