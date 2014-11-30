using UnityEngine;
using System.Collections;

public class EquipmentSlot {

	public enum SlotTypes{
		RIGHTHAND,
		LEFTHAND,
		ACCESSORY
	}

	private SlotTypes slotType;
	private Item equippedItem;

	public EquipmentSlot(SlotTypes t){
		slotType = t;
	}

	public void removeItem(){
		equippedItem = null;
	}

	public SlotTypes SlotType {
		get{ return slotType;}
		set{ slotType = value;}
	}

	public Item EquippedItem {
		get{ return equippedItem;}
		set{ equippedItem = value;}
	}
}
