using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterDatabase : MonoBehaviour {

	private static CharacterDatabase instance = null;

	public static CharacterDatabase Instance {
		get {
			if (instance == null) {
				//Debug.Log("Instancing a new CharacterDatabase");
				GameObject go = Instantiate(Resources.Load ("Prefab/CharacterDatabase")) as GameObject;
				go.name = "Character Database";
			}
			return instance;
		}
	}

	public List<BaseCharacter> characters = new List<BaseCharacter>();
	//public List<BaseCharacter> monsters = new List<BaseCharacter>();

	public BaseCharacter calais;
	public BaseCharacter zetes;
	public BaseCharacter boop;
	public BaseCharacter ashley;

	public void Awake () {
		instance = this;
		buildCharacters ();

		DontDestroyOnLoad (transform.gameObject);
	}

	public void Start(){
		//buildCharacters ();
	}

	public void buildCharacters(){
		//Debug.Log ("Building characters");
		characters.Add ((BaseCharacter)Instantiate(calais, new Vector3(0,0,0), Quaternion.identity));
		//characters[0].mainWeapon = (Weapon)ItemDatabase.getItemByName("Dagger");
		characters.Add ((BaseCharacter)Instantiate(zetes, new Vector3(0,0,0), Quaternion.identity));
		//characters[1].mainWeapon = (Weapon)ItemDatabase.getItemByName("Leather Gloves");
		//monsters.Add ((BaseCharacter)Instantiate(boop, new Vector3(0,0,0), boop.transform.localRotation));
		characters.Add (boop);
		characters.Add (ashley);

		//BaseCharacter ashley = new BaseCharacter("Ashley", new BlackMage());
		//ashley.equip(((StatItem)ItemDatabase.instance.getItemByName("Apprentice Wand")), ashley.equipmentSlots[0]);
		//ashley.Portrait = Resources.Load<Sprite> ("ashley1");
		//characters.Add(ashley);		
		
		//BaseCharacter luc = new BaseCharacter("Luc", new WhiteMage());
		//luc.equip(((StatItem)ItemDatabase.instance.getItemByName("Novice Staff")), luc.equipmentSlots[0]);
		//luc.Portrait = Resources.Load<Sprite> ("luc1");
		//characters.Add(luc);


		for(int i = 0; i < characters.Count ; i++){
			characters[i].initCharacter();
		}

		//for(int i = 0; i < monsters.Count ; i++){
		//	monsters[i].initCharacter();
		//}
	}

	public BaseCharacter getCharacterByName(string name){
		foreach (BaseCharacter bc in characters) {
			if(bc.name == name){
				return bc;
			}
		}
		return null;
	}
}
