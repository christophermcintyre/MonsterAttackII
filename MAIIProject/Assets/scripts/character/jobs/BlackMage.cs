public class BlackMage : Job {
	
	public BlackMage(BaseCharacter bc){
		owner = bc;
		Name = "Black Mage";
		//Dark Mage
		//Wizard
		//Battle Mage

		Actions.Add (new Attack(owner));

	}
}