using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CommandMenu : MonoBehaviour {

	public BaseCharacter activeCharacter;
	public Text activeCharacterName;

	public Ability selectedAction;

	public List<BaseCharacter> targets;
	public BaseCharacter selectedTarget;

	public GameObject targetListPanel;
	public GameObject actionListPanel;

	public ListCharacter listCharacterPrefab;
	public ListAction listActionPrefab;

	public List<ListCharacter> targetDisplayList = new List<ListCharacter>();
	public List<ListAction> actionDisplayList = new List<ListAction>();

	public Button attackButton;
	public Button skillsButton;
	public Button itemButton;
	public Button statusButton;

	//public bool targetListOpen = false;
	//public bool actionListOpen = false;

	public void open(BaseCharacter bc, List<BaseCharacter> t){
		if (this.gameObject.activeSelf) {
			return;
		}
		this.gameObject.SetActive (true);
		activeCharacter = bc;
		targets = t;
		activeCharacterName.text = activeCharacter.Name;
		if (activeCharacter.Skills.Count > 0) skillsButton.enabled = true;
		else skillsButton.enabled = false;
	}

	public void close(){
		activeCharacterName.text = "none";
		activeCharacter = null;
		targets = null;
		selectedTarget = null;
		selectedAction = null;
		closeTargetMenu ();
		closeActionMenu ();
		this.gameObject.SetActive (false);	
	}

	public void openActionMenu(){
		if (targetListPanel.activeSelf) {
			closeTargetMenu();
		}
		if (!actionListPanel.activeSelf) {
			actionListPanel.SetActive(true);
			selectedAction = activeCharacter.Skills[0];
			displayActionList (activeCharacter.Skills);
		} else closeActionMenu();
	}
	
	public void closeActionMenu(){
		actionListPanel.SetActive (false);
		foreach (ListAction obj in actionDisplayList){
			Destroy(obj.gameObject);
		}
		actionDisplayList.Clear ();
	}

	public void displayActionList(List<Ability> actions){
		foreach (Ability a in actions) {
			ListAction l = (ListAction)Instantiate(listActionPrefab);
			actionDisplayList.Add(l);
			l.displayAction(a);
			l.parentMenu = this;
			l.transform.SetParent(actionListPanel.gameObject.transform, false);
		}
	}

	public void openTargetMenu(){
		closeActionMenu();

		if (!targetListPanel.activeSelf) {
			targetListPanel.SetActive (true);
			displayCharacterList (targets);
		} else closeTargetMenu();
	}

	public void closeTargetMenu(){
		targetListPanel.SetActive (false);
		foreach (ListCharacter obj in targetDisplayList) {
			Destroy (obj.gameObject);
		}		
		targetDisplayList.Clear ();
		selectedTarget = null;
	}

	public void displayCharacterList(List<BaseCharacter> characters){

		//Debug.Log (selectedAction.actionName);

		switch (selectedAction.targetType){

		//default to enemy list
		case Ability.TargetType.ENEMY_SINGLE:
			foreach (BaseCharacter bc in characters) {
				if (bc.alive() && !bc.playerControl) {
					ListCharacter l = (ListCharacter)Instantiate(listCharacterPrefab);
					targetDisplayList.Add(l);
					l.displayCharacter(bc);
					l.parentMenu = this;
					//if (bc.playerControl) l.transform.SetParent(allyListPanel.gameObject.transform, false);
					//else l.transform.SetParent(targetListPanel.gameObject.transform, false);
					l.transform.SetParent(targetListPanel.gameObject.transform, false);
				}
			}
			break;

		//default to ally list
		case Ability.TargetType.ALLY_SINGLE:
			foreach (BaseCharacter bc in characters) {
				if (bc.playerControl) {
					ListCharacter l = (ListCharacter)Instantiate(listCharacterPrefab);
					targetDisplayList.Add(l);
					l.displayCharacter(bc);
					l.parentMenu = this;
					//if (bc.playerControl) l.transform.SetParent(allyListPanel.gameObject.transform, false);
					//else l.transform.SetParent(targetListPanel.gameObject.transform, false);
					l.transform.SetParent(targetListPanel.gameObject.transform, false);
				}
			}
			break;

		}
		targetListPanel.SetActive (true);
	}

	public void attackCommand(){
		selectedAction = activeCharacter.Actions [0];
		openTargetMenu ();
	}

	public void confirmAction(){
		activeCharacter.performAction (selectedTarget, selectedAction);
		close ();
	}

	public void skillsCommand(){

	}

	public void itemsCommand(){

	}

}
