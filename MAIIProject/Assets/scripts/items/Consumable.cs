using UnityEngine;
using System.Collections;

public class Consumable : Item {

	public int potency;

	public Consumable(string name, string display, int value, int p){

		itemType = ItemType.CONSUMABLE;

		ItemName = name;
		DisplayName = display;
		ItemValue = value;
		potency = p;

		itemIcon = Resources.Load<Sprite> ("" + name);

	}

	public Consumable(Consumable template){

		itemType = ItemType.CONSUMABLE;

		ItemName = template.ItemName;
		DisplayName = template.DisplayName;
		ItemValue = template.ItemValue;
		potency = template.potency;
		
		itemIcon = Resources.Load<Sprite> ("" + template.ItemName);

	}

	public void use(BaseCharacter bc){
		if (bc == null)	bc = Player.Instance.playerParty [0];
		bc.heal (potency);
	}


	public int Potency {
		get{ return potency;}
		set{ potency = value;}
	}

}
