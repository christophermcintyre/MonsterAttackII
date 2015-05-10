public class Brawler : Job {

	public Brawler(BaseCharacter bc) {
		owner = bc;
		Name = "Brawler";
		MaxHP=120;
		Attack=20;

		//actions.Add (new Attack (owner));
		actions.Add (new Bash (owner));

	}
}
