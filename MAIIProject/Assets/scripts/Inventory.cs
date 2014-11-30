using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory
{

		private List<Item> items = new List<Item> ();
		private Party owner;

		public Inventory (Party p)
		{
				owner = p;
		}

		public void add (Item item)
		{
				items.Add (item);

		}

		public Party Owner {
				get{ return owner;}
				set{ owner = value;}
		}


}

