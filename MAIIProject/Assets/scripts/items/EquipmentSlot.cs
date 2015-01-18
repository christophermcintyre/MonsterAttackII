using UnityEngine;
using System.Collections;

public class EquipmentSlot {

	public enum SlotTypes{
		RIGHTHAND,
		LEFTHAND,
		ACCESSORY
	}

	public BaseCharacter owner;
	private SlotTypes slotType;
	private StatItem equippedItem;

	public EquipmentSlot(SlotTypes t, BaseCharacter bc){
		owner = bc;
		slotType = t;
	}

	public void removeItem(){
		equippedItem = null;
	}

	public SlotTypes SlotType {
		get{ return slotType;}
		set{ slotType = value;}
	}

	public StatItem EquippedItem {
		get{ return equippedItem;}
		set{ equippedItem = value;}
	}
}
