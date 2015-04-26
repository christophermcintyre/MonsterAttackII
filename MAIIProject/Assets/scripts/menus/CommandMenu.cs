using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CommandMenu : MonoBehaviour {

	public BaseCharacter activeCharacter;
	public Text activeCharacterName;

	public List<BaseCharacter> targets;
	public BaseCharacter selectedTarget;

	public GameObject targetListPanel;
	public GameObject allyListPanel;
	public ListCharacter listCharacterPrefab;

	public List<ListCharacter> targetDisplayList = new List<ListCharacter>();

	public bool targetWindowOpen = false;

	public void open(BaseCharacter bc, List<BaseCharacter> t){
		activeCharacter = bc;
		targets = t;
		activeCharacterName.text = activeCharacter.Name;
	}

	public void openTargetMenu(){

		if (!targetWindowOpen) {
			targetWindowOpen = true;
			targetListPanel.transform.parent.gameObject.SetActive (true);
			displayCharacterList (targets);
		} else closeTargetMenu();
	}

	public void closeTargetMenu(){
		targetListPanel.transform.parent.gameObject.SetActive (false);

		foreach (ListCharacter obj in targetDisplayList) {
			Destroy (obj.gameObject);
		}
		
		targetDisplayList.Clear ();
		selectedTarget = null;
		targetWindowOpen = false;

	}

	public void displayCharacterList(List<BaseCharacter> characters){
		
		foreach (BaseCharacter bc in characters) {
			ListCharacter l = (ListCharacter)Instantiate(listCharacterPrefab);
			targetDisplayList.Add(l);
			l.displayCharacter(bc);
			if (bc.playerControl) l.transform.SetParent(allyListPanel.gameObject.transform, false);
			else l.transform.SetParent(targetListPanel.gameObject.transform, false);
		}
		targetListPanel.SetActive (true);
	}

	public void attackCommand(){
		activeCharacter.attack (selectedTarget);

		closeTargetMenu ();
		this.gameObject.SetActive (false);	
	}

	public void skillsCommand(){

	}

	public void itemsCommand(){

	}

}
