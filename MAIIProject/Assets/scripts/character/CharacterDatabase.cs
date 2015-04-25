using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterDatabase : MonoBehaviour {

	public List<BaseCharacter> characters = new List<BaseCharacter>();
	public List<BaseCharacter> monsters = new List<BaseCharacter>();

	public BaseCharacter calais;
	public BaseCharacter zetes;
	public BaseCharacter boop;


	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void Start(){
		buildCharacters ();
	}

	public void buildCharacters(){

		//calais = (BaseCharacter)Instantiate(prefab_calais, new Vector3(0,0,0), prefab_calais.transform.localRotation);
		//calais.initCharacter ();
		//calais.equip(((StatItem)ItemDatabase.instance.getItemByName("Faerie Flute")), calais.equipmentSlots[0]);

		//characters.Add(calais);


		characters.Add ((BaseCharacter)Instantiate(calais, new Vector3(0,0,0), Quaternion.identity));
		characters.Add ((BaseCharacter)Instantiate(zetes, new Vector3(0,0,0), zetes.transform.localRotation));

		monsters.Add ((BaseCharacter)Instantiate(boop, new Vector3(0,0,0), boop.transform.localRotation));

		//BaseCharacter calais = new BaseCharacter("Calais", new Musician());
		//calais.equip(((StatItem)ItemDatabase.instance.getItemByName("Faerie Flute")), calais.equipmentSlots[0]);
		//calais.equip(((StatItem)ItemDatabase.instance.getItemByName("Lucky Bell")), calais.equipmentSlots[2]);
		//calais.Portrait = Resources.Load<Sprite> ("calais1");
		//calais.model = prefab_calais;
		
		//BaseCharacter zetes = new BaseCharacter("Zetes", new Thief());

		//zetes.initCharacter ();
		//zetes.equip(((StatItem)ItemDatabase.instance.getItemByName("Dagger")), zetes.equipmentSlots[0]);
		//characters.Add(zetes);

		/*BaseCharacter ashley = new BaseCharacter("Ashley", new BlackMage());
		ashley.equip(((StatItem)ItemDatabase.instance.getItemByName("Apprentice Wand")), ashley.equipmentSlots[0]);
		ashley.Portrait = Resources.Load<Sprite> ("ashley1");
		characters.Add(ashley);		
		
		BaseCharacter luc = new BaseCharacter("Luc", new WhiteMage());
		luc.equip(((StatItem)ItemDatabase.instance.getItemByName("Novice Staff")), luc.equipmentSlots[0]);
		luc.Portrait = Resources.Load<Sprite> ("luc1");
		characters.Add(luc);
*/

		//BaseCharacter boop = new BaseCharacter ("Boop", new Brawler ());
		//boop.model = prefab_boop;
		///boop.initCharacter ();
		//monsters.Add (boop);


		for(int i = 0; i < characters.Count ; i++){
			characters[i].initCharacter();
		}

		for(int i = 0; i < monsters.Count ; i++){
			monsters[i].initCharacter();
		}
	}

	public BaseCharacter getCharacterByName(string name){
		foreach (BaseCharacter bc in monsters) {
			if(bc.name == name){
				return bc;
				//return copyCharacter(bc);
			}
		}
		return null;
	}

	public BaseCharacter copyCharacter(BaseCharacter template){
		return new BaseCharacter (template);
	}
}
