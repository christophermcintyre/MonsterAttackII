using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ListItem : MonoBehaviour, IPointerDownHandler {

	public int index;

	public Item item;
	public Image imageIcon;
	public Text nameText;
	public Text infoText;

	public Menu parentMenu;

	public void Start () {
		imageIcon = gameObject.transform.GetChild (0).GetComponent<Image>();
		nameText = gameObject.transform.GetChild (1).GetComponent<Text>();
		infoText = gameObject.transform.GetChild (2).GetComponent<Text>();

	}

	public void OnPointerDown(PointerEventData data) {
		if (data.button == PointerEventData.InputButton.Left) {
			parentMenu.select(this);
		}
	}

	public void displayItem(Item i) {
		Start ();
		item = i;
		imageIcon.sprite = i.itemIcon;
		nameText.text = i.DisplayName;
	}
}
