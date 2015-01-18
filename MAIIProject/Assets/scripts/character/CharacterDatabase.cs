using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterDatabase : MonoBehaviour {

	public static CharacterDatabase instance;
	public List<BaseCharacter> characters = new List<BaseCharacter>();
	public List<BaseCharacter> monsters = new List<BaseCharacter>();

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
		instance = this;

	}

	public void Start(){

		buildCharacters ();
	}

	//need a method to copy characters;

	public void buildCharacters(){

		//Debug.Log("building characters");
		
		BaseCharacter calais = new BaseCharacter("Calais", new Musician());
		calais.equip(((StatItem)ItemDatabase.instance.getItemByName("Faerie Flute")), calais.equipmentSlots[0]);
		calais.equip(((StatItem)ItemDatabase.instance.getItemByName("Lucky Bell")), calais.equipmentSlots[2]);
		calais.Portrait = Resources.Load<Sprite> ("calais1");
		characters.Add(calais);
		
		BaseCharacter zetes = new BaseCharacter("Zetes", new Thief());
		zetes.equip(((StatItem)ItemDatabase.instance.getItemByName("Dagger")), zetes.equipmentSlots[0]);
		zetes.Portrait = Resources.Load<Sprite> ("calais2");
		characters.Add(zetes);		
		
		BaseCharacter ashley = new BaseCharacter("Ashley", new BlackMage());
		ashley.equip(((StatItem)ItemDatabase.instance.getItemByName("Apprentice Wand")), ashley.equipmentSlots[0]);
		ashley.Portrait = Resources.Load<Sprite> ("ashley1");
		characters.Add(ashley);		
		
		BaseCharacter luc = new BaseCharacter("Luc", new WhiteMage());
		luc.equip(((StatItem)ItemDatabase.instance.getItemByName("Novice Staff")), luc.equipmentSlots[0]);
		luc.Portrait = Resources.Load<Sprite> ("luc1");
		characters.Add(luc);

		//BaseCharacter direrat = new BaseCharacter("Dire Rat", new Thief());
		//monsters.Add(direrat);

		BaseCharacter goblin = new BaseCharacter ("Goblin", new Brawler ());
		monsters.Add (goblin);

		//BaseCharacter hoblin = new BaseCharacter ("Hoblin", new Brawler ());
		//monsters.Add (hoblin);

		//BaseCharacter kobold = new BaseCharacter ("Kobold", new Brawler ());
		//monsters.Add (kobold);

		//BaseCharacter cockatrice = new BaseCharacter ("Cockatrice", new DarkKnight ());
		//monsters.Add (cockatrice);
	}

	public BaseCharacter getCharacterByName(string name){
		foreach (BaseCharacter bc in monsters) {
			if(bc.name == name){
				return copyCharacter(bc);
			}
		}
		return null;
	}

	public BaseCharacter copyCharacter(BaseCharacter template){
		return new BaseCharacter (template);
	}
}
