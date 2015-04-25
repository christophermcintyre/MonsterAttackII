using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CommandMenu : MonoBehaviour {

	public BaseCharacter activeCharacter;
	public List<BaseCharacter> targets;

	public BaseCharacter selectedTarget;

	public Text activeCharacterName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void open(BaseCharacter bc, List<BaseCharacter> t){
		activeCharacter = bc;
		targets = t;
		activeCharacterName.text = activeCharacter.Name;
	}

	public void attackCommand(){
		Debug.Log("Attack button clicked");
		activeCharacter.chooseAction (targets);

	}

	public void skillsCommand(){

	}

	public void itemsCommand(){

	}

}
