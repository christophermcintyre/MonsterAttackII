using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class ItemDatabase : MonoBehaviour {

	public TextAsset itemInventory;
	public static List<Item> inventoryItems = new List<Item> ();

	private List<Dictionary<string, string>> inventoryItemsDictionary = new List<Dictionary<string, string>>();
	private Dictionary<string, string> inventoryDictionary;


	void Awake(){
		ReadItemsFromDatabase ();
		for(int i = 0; i < inventoryItemsDictionary.Count; i++){
			inventoryItems.Add(new Item(inventoryItemsDictionary[i]));
		}

	}

	public void ReadItemsFromDatabase(){
		XmlDocument xmlDocument = new XmlDocument ();
		xmlDocument.LoadXml (itemInventory.text);
		XmlNodeList itemList = xmlDocument.GetElementsByTagName ("Item");

		foreach (XmlNode itemInfo in itemList){
			XmlNodeList itemContent = itemInfo.ChildNodes;
			inventoryDictionary = new Dictionary<string, string>();


			foreach(XmlNode content in itemContent){
				switch(content.Name){
				case "ItemName":
					inventoryDictionary.Add("ItemName", content.InnerText);
					break;
				case "ItemId":
					inventoryDictionary.Add("ItemID", content.InnerText);
					break;
				case "ItemType":
					inventoryDictionary.Add("ItemType", content.InnerText);
					break;

				}

			}

			inventoryItemsDictionary.Add(inventoryDictionary);

		}

	}

}
