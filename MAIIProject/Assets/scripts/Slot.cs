using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler {

	public StatItem item;
	public Image imageIcon;
	public int slotIndex;
	public Item.ItemType type;

	public Player player;
	public BaseCharacter activeCharacter;
	public Menu activeMenu;

	void Start () {

		player = (Player)FindObjectOfType (typeof(Player));

		imageIcon = gameObject.transform.GetChild (0).GetComponent<Image>();

	
	}

	void Update () {

		if (item != null) {
			imageIcon.sprite = item.itemIcon;
			imageIcon.enabled = true;
		}
		else{
			imageIcon.enabled = false;
			imageIcon.sprite = null;
		}
	
	}

	public void reset(){

		item = null;
		//GetComponentInParent<StatusMenu> ().refresh ();

	}


	public void OnPointerDown(PointerEventData data) {
		if (data.button == PointerEventData.InputButton.Left) {

			//GetComponentInParent<MenuManager>().itemType = type;
			GameObject.Find("Equipment Menu").GetComponent<EquipmentMenu>().activeCharacter = GameObject.Find("Status Menu").GetComponent<StatusMenu>().activeCharacter;
			GameObject.Find("Equipment Menu").GetComponent<EquipmentMenu>().iType = type;
			GameObject.Find("Equipment Menu").GetComponent<EquipmentMenu>().selectedSlot = slotIndex;
			GetComponentInParent<MenuManager>().showMenu(GameObject.Find("Equipment Menu").GetComponent<EquipmentMenu>());
		}

		if (data.button == PointerEventData.InputButton.Right && item != null) {
			//item.unequip();
			activeCharacter = GameObject.Find ("Status Menu").GetComponent<StatusMenu> ().activeCharacter;

			switch (slotIndex) {
				
			case 0:
				if (activeCharacter.mainWeapon != null) {
					player.inventory.add(activeCharacter.mainWeapon);
				}
				activeCharacter.mainWeapon = null;
				break;
				
			case 1:
				if (activeCharacter.offHandWeapon != null) {
					player.inventory.add(activeCharacter.offHandWeapon);
				}
				activeCharacter.offHandWeapon = null;
				break;
				
			case 2:
				if (activeCharacter.accessory1 != null) {
					player.inventory.add(activeCharacter.accessory1);
				}
				activeCharacter.accessory1 = null;
				break;
				
			case 3:
				if (activeCharacter.accessory2 != null) {
					player.inventory.add(activeCharacter.accessory2);
				}
				activeCharacter.accessory2 = null;
				break;
			}
			reset();

		}

	}

}
