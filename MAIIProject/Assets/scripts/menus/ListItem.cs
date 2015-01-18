using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ListItem : MonoBehaviour, IPointerDownHandler {

	public StatItem item;
	public Image imageIcon;
	public Text nameText;

	void Start () {
		imageIcon = gameObject.transform.GetChild (0).GetComponent<Image>();
		nameText = gameObject.transform.GetChild (1).GetComponent<Text>();
	}

	public void OnPointerDown(PointerEventData data) {
		if (data.button == PointerEventData.InputButton.Left) {
			GetComponentInParent<EquipmentMenu>().selectedItem = item;
			GetComponentInParent<EquipmentMenu>().refresh();
			nameText.color = new Color (255, 255, 0);
		}
	}

	public void displayItem(StatItem i) {
		Start ();
		item = i;
		imageIcon.sprite = i.itemIcon;
		nameText.text = i.DisplayName;
		if (i.equipped())	nameText.color = new Color (0, 255, 0);
	}

	public void equipItem (){
		BaseCharacter character = this.GetComponentInParent<EquipmentMenu>().slot.owner;
		character.equip ((StatItem)item, this.GetComponentInParent<EquipmentMenu> ().slot);
	}
}
