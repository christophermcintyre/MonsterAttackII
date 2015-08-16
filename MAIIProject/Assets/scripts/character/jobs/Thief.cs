public class Thief : Job {

	public Thief(BaseCharacter bc){

		Name = "Thief";
		owner = bc;

		attributes = new AttributeDatabase(1, 50,600,0,0,4,50,4,50,10,100,10,100,10,100);	
		CritRate = 10.0f;
		CritStrength = 2.0f;

		actions.Add (new Steal (owner));
		//actions.Add (new Trick (owner));
		//actions.Add (new Mimic (owner));
		//actions.Add (new SneakAttack (owner));
		levelUp ();

	}
}