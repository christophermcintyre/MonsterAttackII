public class Brawler : Job {

	public Brawler(BaseCharacter bc) {

		Name = "Brawler";
		owner = bc;

		attributes = new AttributeDatabase(0, 100,750,0,0,7,75,7,75,7,75,7,75,7,75);
		CritRate = 15.0f;
		CritStrength = 1.5f;

		actions.Add (new Bash (owner));

		levelUp ();

	}
}
