using UnityEngine;
using System.Collections;

public interface IItemObject {

	int ItemID { get; set; }
	int ItemIcon { get; set; }
	string ItemName { get; set; }
	string ItemDesc { get; set; }

	int ItemValue { get; set; }


	//ItemType itemType;
	//public int maxStackSize;
	//public int currentStackSize;

}
