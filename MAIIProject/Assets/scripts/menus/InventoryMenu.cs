using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryMenu : Menu {

	public Text itemName;
	public Text itemLVL;
	public Text itemType;
	public Text itemEXP;
	public Text itemBaseStat;
	public Text itemDelay;

	public List<BaseCharacter> partyList;
	public List<GameObject> partyMemberPanels;
	public Image[] portraits;
	public Text[] names;
	public Text[] jobs;
	public Text[] vitals;
	
	public GameObject itemListPanel;
	public ListItem listItemPrefab;

	public List<ListItem> itemDisplayList = new List<ListItem>();
	public ListItem selectedListItem;

	public Button useButton;
	public GameObject characterSelectionPanel;

	public Button dropButton;
	public GameObject dropConfirmationPanel;

	void Start () {
		foreach(GameObject go in partyMemberPanels){
			go.GetComponent<Button>().enabled = false;
		}
		partyList = Player.Instance.playerParty;
	}

	public override void open(){
		dropConfirmationPanel.SetActive(false);
		useButton.interactable = false;
		dropButton.interactable = false;
		displayList (Player.Instance.inventory.Items);	
		refresh ();
	}

	public override void close(){		
		foreach (ListItem obj in itemDisplayList) {
			Destroy (obj.gameObject);
		}		
		itemDisplayList.Clear ();
		selectedListItem = null;
	}
	
	public override void refresh(){

		if (characterSelectionPanel.activeSelf) {
			foreach (BaseCharacter member in partyList) {		
				partyMemberPanels[partyList.IndexOf(member)].GetComponent<Button>().enabled = true;
				portraits[partyList.IndexOf(member)].color = new Color32(255, 255, 255, 255);
				portraits[partyList.IndexOf(member)].sprite = member.Portrait;
				names[partyList.IndexOf(member)].text = member.Name;
				jobs[partyList.IndexOf(member)].text = "LVL " + member.CurrentJob.Level + " " + member.CurrentJob.Name;
				vitals[partyList.IndexOf(member)].text = "HP " + member.CurrentHp + "/" + member.CurrentJob.MaxHP;
			}
			return;
		}

		if (selectedListItem == null ) {
			if (itemDisplayList.Count > 0) {
				selectedListItem = itemDisplayList [0];
				dropButton.interactable = true;
			} else {
				dropButton.interactable = false;
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
			
			itemName.text = selectedListItem.item.DisplayName;		
			
			if(selectedListItem.item.itemType == Item.ItemType.ACCESSORY){
				Accessory selectedAcc = (Accessory)selectedListItem.item;
				itemLVL.text  = ("LVL: " + selectedAcc.Level);			
				itemEXP.text = ("EXP: " + selectedAcc.CurrentExp + "/" + selectedAcc.expToLevel);
				itemType.text = ("Type: " + selectedAcc.AccessoryType);
				itemBaseStat.text = ("DEF: " + selectedAcc.Armor);
				itemDelay.text = "";
				useButton.interactable = false;
			}
			
			if(selectedListItem.item.itemType == Item.ItemType.WEAPON){
				Weapon selectedWeapon = (Weapon)selectedListItem.item;
				itemLVL.text  = ("LVL: " + selectedWeapon.Level);			
				itemEXP.text = ("EXP: " + selectedWeapon.CurrentExp + "/" + selectedWeapon.expToLevel);
				itemType.text = ("Type: " + selectedWeapon.WeaponType);
				itemBaseStat.text = ("DMG: " + selectedWeapon.Damage);
				itemDelay.text = ("Delay: " + selectedWeapon.Delay);
				useButton.interactable = false;
			}

			if(selectedListItem.item.itemType == Item.ItemType.CONSUMABLE){
				Consumable selectedConsumable = (Consumable)selectedListItem.item;
				itemType.text = ("Type: Consumable");
				itemBaseStat.text = ("Potency: " + selectedConsumable.Potency);
				itemDelay.text = "";
				useButton.interactable = true;
			}
		}

		foreach (ListItem l in itemDisplayList) {
			if (l == selectedListItem) l.nameText.color = new Color (255, 255, 0);
			else l.transform.GetChild (1).GetComponent<Text>().color = new Color(255,255,255);
		}

	}

	public void displayList(List<Item> items){
		foreach (Item i in items) {
			ListItem l = (ListItem)Instantiate(listItemPrefab);
			itemDisplayList.Add(l);
			l.displayItem(i);
			l.transform.SetParent(itemListPanel.transform, false);
			l.parentMenu = this;
		}
	}
	
	public override void select(ListItem l){
		dropConfirmationPanel.SetActive(false);
		selectedListItem = l;
		refresh();
	}

	public void useItem(int index){
		Consumable tempConsumable = (Consumable)selectedListItem.item;
		tempConsumable.use (Player.Instance.playerParty[index]);

		Player.Instance.inventory.Items.Remove(selectedListItem.item);
		itemDisplayList.Remove (selectedListItem);
		Destroy (selectedListItem.gameObject);
		selectedListItem = null;
		refresh ();
	}

	public void dropItem(){
		if (selectedListItem){
			Player.Instance.inventory.Items.Remove(selectedListItem.item);
			itemDisplayList.Remove (selectedListItem);
			Destroy (selectedListItem.gameObject);
			selectedListItem = null;
			refresh();
		}
	}
}


