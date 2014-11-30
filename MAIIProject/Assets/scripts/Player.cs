using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public static Party playerParty;
	private static string playerName;

	public static Player instance;

	void Awake(){
		instance = this;
	}

	void Start () {
		playerName = "Player";
		playerParty = createParty ();	
	}

	void Update () {
	
	}


	public Party createParty(){

		Party party = new Party(playerName);

		Weapon dagger = new Weapon("Dagger", Weapon.WeaponTypes.DAGGER, 24, 150);
		dagger.setRequiredLevel(1);
		playerParty.inventory.add(dagger);			
		playerParty.inventory.add(new Weapon("Spiked Gloves", Weapon.WeaponTypes.GLOVE, 18, 100));
		playerParty.inventory.add(new Weapon("Bronze Sword", Weapon.WeaponTypes.SWORD, 30, 200));
		playerParty.inventory.add(new Weapon("Club", Weapon.WeaponTypes.MACE, 25, 175));			
		playerParty.inventory.add(new Weapon("Wooden Sword", Weapon.WeaponTypes.SWORD, 22, 200));
		Weapon bronzeAxe = new Weapon("Bronze Axe", Weapon.WeaponTypes.AXE, 34, 250);
		bronzeAxe.setRequiredLevel(2);			
		playerParty.inventory.add(bronzeAxe);
		playerParty.inventory.add(new Weapon("Teddy Bear", Weapon.WeaponTypes.TOY, 15, 200));
		playerParty.inventory.add(new Weapon("Faerie Flute", Weapon.WeaponTypes.FLUTE, 10, 175));
		playerParty.inventory.add(new Weapon("Maple Harp", Weapon.WeaponTypes.HARP, 18, 100));
		playerParty.inventory.add(new Accessory("Lucky Bell", Accessory.AccessoryTypes.CATBELL, 5));
		playerParty.inventory.add(new Accessory("Speedy Bell", Accessory.AccessoryTypes.CATBELL, 5));
		playerParty.inventory.add(new Accessory("Spiked Bell", Accessory.AccessoryTypes.CATBELL, 5));
		Accessory magicBell = new Accessory("Magic Bell", Accessory.AccessoryTypes.CATBELL, 5);			
		//Effect effect = new Regen("Auto-Regen",5,true);
		//magicBell.addEffect(Effect.autoRegen);
		playerParty.inventory.add(magicBell);
		//playerParty.inventory.add(new Consumable(Consumable.potion));
		//playerParty.inventory.add(new Consumable(Consumable.potion));
		//playerParty.inventory.add(new Item("Shiny Rock", ItemType.misc));
		playerParty.addMoney(200);
		
		BaseCharacter a;

			a = new BaseCharacter("Calais", new Musician());
			//a.sprite = new Image("res/Calais_battle_1.png");
			//a.portrait = new Image("res/portrait_calais.png");
			a.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.RIGHTHAND));
			a.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.LEFTHAND));
			a.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY));
			a.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY));
			//a.setBehavior(new PlayerControllable(a));
			//a.addJob(JobHandler.THIEF);
			playerParty.addMember(a);
			//a.equip(a.party.inventory.get(7), a.equipmentSlots.get(0));
				
		
		BaseCharacter b;

			b = new BaseCharacter("Zetes", new Thief());
			//b.sprite = new Image("res/Calais_battle_1.png");
			//b.portrait = new Image("res/portrait_calais.png");
			b.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.RIGHTHAND));
			b.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.LEFTHAND));
			b.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY));
			b.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY));
			//b.setBehavior(new PlayerControllable(b));
			//b.addJob(JobHandler.WARRIOR);
			playerParty.addMember(b);
			//b.equip(b.party.inventory.getItems().get(1), b.equipmentSlots.get(0));
			
		
		BaseCharacter c;

			c = new BaseCharacter("Ashley", new BlackMage());
			//c.sprite = new Image("res/Calais_battle_1.png");
			c.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.RIGHTHAND));
			c.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.LEFTHAND));
			c.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY));
			c.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY));
			//c.setBehavior(new PlayerControllable(c));
			//c.addJob(JobHandler.BLACKMAGE);
			//c.addJob(JobHandler.DARKKNIGHT);
			//c.addJob(JobHandler.MUSICIAN);
			playerParty.addMember(c);
			//c.equip(c.party.inventory.getItems().get(2), c.equipmentSlots.get(0));

		
		BaseCharacter d;

			d = new BaseCharacter("Luc", new WhiteMage());
			//d.sprite = new Image("res/Calais_battle_1.png");
			d.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.RIGHTHAND));
			d.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.LEFTHAND));
			d.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY));
			d.equipmentSlots.Add(new EquipmentSlot(EquipmentSlot.SlotTypes.ACCESSORY));
			//d.setBehavior(new PlayerControllable(d));
			playerParty.addMember(d);
			//d.equip(d.party.inventory.getItems().get(3), d.equipmentSlots.get(0));


		return party;
	}

	//public Party PlayerParty{
	//	get{ return playerParty;}
	//	set{ playerParty = value;}
	//}

}
