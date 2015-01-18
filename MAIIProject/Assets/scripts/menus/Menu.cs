﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	private Animator animator;
	private CanvasGroup canvasGroup;
	public BaseCharacter character;
	public EquipmentSlot slot;
	
	public bool IsOpen{
		get { return animator.GetBool ("IsOpen"); }
		set { animator.SetBool ("IsOpen", value); }
	}

	public void Awake(){
		
		animator = GetComponent<Animator> ();
		canvasGroup = GetComponent<CanvasGroup> ();
		
		var rect = GetComponent<RectTransform> ();
		rect.offsetMax = rect.offsetMin = new Vector2 (0, 0);		
	}

	public virtual void open(){
	}

	public virtual void close(){
	}

	public virtual void refresh(){
	}

	public void DisplayCharacter(BaseCharacter displayCharacter){

		character = displayCharacter;
	}

	public void DisplaySlot(EquipmentSlot displaySlot){

		slot = displaySlot;
	}

	public void Update(){
		
		if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
			canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
		} else {
			canvasGroup.blocksRaycasts = canvasGroup.interactable =  true;
		}
	}
}