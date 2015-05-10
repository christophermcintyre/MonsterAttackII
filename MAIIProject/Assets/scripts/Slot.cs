using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler {

	public StatItem item;
	public Image imageIcon;
	public int slotIndex;
	public Item.ItemType type;

	public Menu parentMenu;
	public EquipmentMenu equipmentMenu;

	void Start () {
		imageIcon = gameObject.transform.GetChild (0).GetComponent<Image>();
		refresh ();
	}

	public void refresh(){
		if (item != null) {
			imageIcon.sprite = item.itemIcon;
			imageIcon.enabled = true;
		}
		else {
			imageIcon.enabled = false;
			imageIcon.sprite = null;
		}
	}

	public void reset(){
		item = null;
		refresh ();
	}

	public void OnPointerDown(PointerEventData data) {
		if (data.button == PointerEventData.InputButton.Left) {
			equipmentMenu.activeCharacter = parentMenu.activeCharacter;
			equipmentMenu.iType = type;
			equipmentMenu.selectedSlot = slotIndex;
			GetComponentInParent<MenuManager>().showMenu(equipmentMenu);
		}

		if (data.button == PointerEventData.InputButton.Right && item != null) {
			//equipmentMenu.activeCharacter = parentMenu.activeCharacter;
			switch (slotIndex) {
				
			case 0:
				if (parentMenu.activeCharacter.mainWeapon != null) {
					Player.Instance.inventory.add(parentMenu.activeCharacter.mainWeapon);
				}
				parentMenu.activeCharacter.mainWeapon = null;
				break;
				
			case 1:
				if (parentMenu.activeCharacter.offHandWeapon != null) {
					Player.Instance.inventory.add(parentMenu.activeCharacter.offHandWeapon);
				}
				parentMenu.activeCharacter.offHandWeapon = null;
				break;
				
			case 2:
				if (parentMenu.activeCharacter.accessory1 != null) {
					Player.Instance.inventory.add(parentMenu.activeCharacter.accessory1);
				}
				parentMenu.activeCharacter.accessory1 = null;
				break;
				
			case 3:
				if (parentMenu.activeCharacter.accessory2 != null) {
					Player.Instance.inventory.add(parentMenu.activeCharacter.accessory2);
				}
				parentMenu.activeCharacter.accessory2 = null;
				break;
			}
			reset();
		}
	}
}
