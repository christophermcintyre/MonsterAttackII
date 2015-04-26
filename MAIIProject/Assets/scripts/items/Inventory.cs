using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {

	private List<Item> items = new List<Item> ();

	public void add (Item item)	{
		items.Add (item);
	}

	public void addItems (List<Item> itemList){
		items.AddRange (itemList);
	}

	public bool contains (Item item) {
		if (items.Contains(item)) return true;
		else return false;
	}

	public void get (Item item) {

	}

	public void remove (Item item) {

	}

	public List<Item> Items {
		get{ return items; }
		set{ items = value; }
	}

}

