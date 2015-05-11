using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopMenu : Menu {
	
	public Text itemName;
	public Text itemLVL;
	public Text itemType;
	public Text itemEXP;
	public Text itemBaseStat;
	public Text itemDelay;

	public Text itemPrice;
	public Text playerFunds;

	public List<Item> shopInventory;

	public float shopBuyPercent = 1.2f;
	public float shopSellPercent = 0.8f;

	//public List<BaseCharacter> partyList;
	//public List<GameObject> partyMemberPanels;
	//public Image[] portraits;
	//public Text[] names;
	//public Text[] jobs;
	//public Text[] vitals;
	
	public GameObject itemListPanel;
	public ListItem listItemPrefab;
	
	public List<ListItem> itemDisplayList = new List<ListItem>();
	public ListItem selectedListItem;
	
	//public Button useButton;
	//public GameObject characterSelectionPanel;
	
	public Button buyButton;
	public GameObject buyConfirmationPanel;
	
	void Start () {
		shopInventory = ItemDatabase.Instance.getBasicShopInventory();
	}
	
	public override void open(){
		buyConfirmationPanel.SetActive(false);
		buyButton.interactable = false;
		displayList (shopInventory);	
		refresh ();
	}
	
	public override void close(){
		buyConfirmationPanel.SetActive(false);
		foreach (ListItem obj in itemDisplayList) {
			Destroy (obj.gameObject);
		}		
		itemDisplayList.Clear ();
		selectedListItem = null;
	}
	
	public override void refresh(){
		
		if (selectedListItem == null ) {
			if (itemDisplayList.Count > 0) {
				selectedListItem = itemDisplayList [0];
				buyButton.interactable = true;
			} else {
				buyButton.interactable = false;
				itemName.text = "";	
				itemLVL.text  = "";			
				itemEXP.text = "";
				itemType.text = "";
				itemBaseStat.text = "";
				itemDelay.text = "";
				return;
			}
		}
		
		if (selectedListItem != null) {
			
			//itemName.text = selectedListItem.item.DisplayName;
			itemName.text = shopInventory[selectedListItem.index].DisplayName;
			itemPrice.text = "Price: " + (int)(shopInventory[selectedListItem.index].ItemValue * shopBuyPercent);
			playerFunds.text = "Funds: " + Player.Instance.Funds;
			
			if(shopInventory[selectedListItem.index].itemType == Item.ItemType.ACCESSORY){
				Accessory selectedAcc = (Accessory)shopInventory[selectedListItem.index];
				itemLVL.text  = ("LVL: " + selectedAcc.Level);			
				itemEXP.text = ("EXP: " + selectedAcc.CurrentExp + "/" + selectedAcc.expToLevel);
				itemType.text = ("Type: " + selectedAcc.AccessoryType);
				itemBaseStat.text = ("DEF: " + selectedAcc.Armor);
				itemDelay.text = "";

			}
			
			if(shopInventory[selectedListItem.index].itemType == Item.ItemType.WEAPON){
				Weapon selectedWeapon = (Weapon)shopInventory[selectedListItem.index];
				itemLVL.text  = ("LVL: " + selectedWeapon.Level);			
				itemEXP.text = ("EXP: " + selectedWeapon.CurrentExp + "/" + selectedWeapon.expToLevel);
				itemType.text = ("Type: " + selectedWeapon.WeaponType);
				itemBaseStat.text = ("DMG: " + selectedWeapon.Damage);
				itemDelay.text = ("Delay: " + selectedWeapon.Delay);
			}
			
			if(shopInventory[selectedListItem.index].itemType == Item.ItemType.CONSUMABLE){
				Consumable selectedConsumable = (Consumable)shopInventory[selectedListItem.index];
				itemLVL.text  = ("LVL: -");			
				itemEXP.text = ("EXP: -");
				itemType.text = ("Type: Consumable");
				itemBaseStat.text = ("Potency: " + selectedConsumable.Potency);
				itemDelay.text = "";
			}
		}

		if (Player.Instance.Funds > (int)(shopInventory[selectedListItem.index].ItemValue * shopBuyPercent)) {
			buyButton.interactable = true;
		} else buyButton.interactable = false;
		
		foreach (ListItem l in itemDisplayList) {
			if (l == selectedListItem) l.nameText.color = new Color (255, 255, 0);
			else l.transform.GetChild (1).GetComponent<Text>().color = new Color(255,255,255);
		}
		
	}
	
	public void displayList(List<Item> items){
		foreach (Item i in items) {
			ListItem l = (ListItem)Instantiate(listItemPrefab);
			itemDisplayList.Add(l);
			l.Start ();
			l.index = shopInventory.IndexOf(i);
			l.nameText.text = (i.DisplayName);
			l.imageIcon.sprite = i.itemIcon;
			l.infoText.text = "" + (int)(i.ItemValue * shopBuyPercent) + "g";
			//l.displayItem(i);
			l.transform.SetParent(itemListPanel.transform, false);
			l.parentMenu = this;
		}
	}
	
	public override void select(ListItem l){
		buyConfirmationPanel.SetActive(false);
		selectedListItem = l;
		//shopInventory[l.index];
		refresh();
	}
	
	public void buyItem(int index){
		if (selectedListItem){
			Player.Instance.inventory.Items.Add(ItemDatabase.Instance.getItemByName(shopInventory[selectedListItem.index].DisplayName));
			Player.Instance.removeMoney((int)(shopInventory[selectedListItem.index].ItemValue * shopBuyPercent));
			refresh();
		}
	}
	
	public void sellItem(){
		if (selectedListItem){
			Player.Instance.inventory.Items.Remove(Player.Instance.inventory.Items[selectedListItem.index]);
			Player.Instance.addMoney((int)(Player.Instance.inventory.Items[selectedListItem.index].ItemValue * shopSellPercent));
			itemDisplayList.Remove (selectedListItem);
			Destroy (selectedListItem.gameObject);
			selectedListItem = null;
			refresh();
		}
	}
}
