﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler {

	public StatItem item;
	public Image imageIcon;
	public int slotIndex;


	void Start () {
		imageIcon = gameObject.transform.GetChild (0).GetComponent<Image>();
	
	}

	void Update () {

		if (item != null) {
			imageIcon.sprite = item.itemIcon;
			imageIcon.enabled = true;
		}
		else{
			imageIcon.enabled = false;
			imageIcon.sprite = null;
		}
	
	}

	public void reset(){

		item = null;
		//GetComponentInParent<StatusMenu> ().reset ();


	}


	public void OnPointerDown(PointerEventData data) {
		if (data.button == PointerEventData.InputButton.Left) {

			GetComponentInParent<MenuManager>().selectSlot(slotIndex);
			GetComponentInParent<MenuManager>().showMenu(GameObject.Find("Equipment Menu").GetComponent<EquipmentMenu>());
		}

		if (data.button == PointerEventData.InputButton.Right && item != null) {

			item.unequip();
			reset();

		}

	}

}