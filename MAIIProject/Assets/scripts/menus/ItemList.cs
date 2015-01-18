using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemList : MonoBehaviour {

	public ListItem listItem; //reference to listItem prefab
	public List<ListItem> list;

	public void displayList(List<Item> items){

		foreach (StatItem i in items) {
			ListItem l = (ListItem)Instantiate(listItem);
			list.Add(l);
			l.GetComponent<ListItem>().displayItem(i);
			l.transform.parent = this.gameObject.transform;
		}
	}

	public void closeList(){

		foreach (ListItem obj in list) {
			Destroy (obj.gameObject);
		}
		list.Clear ();
	}

	public void refresh(){

		foreach (ListItem obj in list) {
			obj.transform.GetChild (1).GetComponent<Text>().color = new Color(255,255,255);
		}
	}
}
