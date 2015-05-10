using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ListCharacter : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
	
	public BaseCharacter character;
	public CommandMenu parentMenu;

	public Image imageIcon;
	public Text nameText;

	public GameObject targetCursor;
	
	void Start () {

		targetCursor = GameObject.FindGameObjectWithTag ("Cursor");

		imageIcon = gameObject.transform.GetChild (0).GetComponent<Image>();
		nameText = gameObject.transform.GetChild (1).GetComponent<Text>();
	}

	public void OnPointerEnter(PointerEventData data){
		//Debug.Log ("Mouse Enter");
		targetCursor.GetComponent<Renderer> ().enabled = true;
		targetCursor.transform.position = character.transform.position;
	}

	public void OnPointerExit(PointerEventData data){		
		//Debug.Log ("Mouse Exit");
		targetCursor.GetComponent<Renderer> ().enabled = false;
	}
	
	public void OnPointerDown(PointerEventData data) {
		if (data.button == PointerEventData.InputButton.Left) {
			parentMenu.selectedTarget = character;
			parentMenu.confirmAction();
			//GetComponentInParent<CommandMenu>().refresh();
			//nameText.color = new Color (255, 255, 0);
			targetCursor.GetComponent<Renderer> ().enabled = false;
		}
	}
	
	public void displayCharacter(BaseCharacter bc){
		Start ();
		character = bc;
		nameText.text = bc.Name;
	}
}