public class BlackMage : Job {
	
	public BlackMage(BaseCharacter bc){

		Name = "Black Mage";
		owner = bc;

		attributes = new AttributeDatabase(0,50,500,30,500,4,50,4,50,4,50,7,75,7,75);
		CritRate = 10.0f;
		CritStrength = 1.5f;

		Actions.Add (new Attack(owner));

		levelUp ();

	}
}