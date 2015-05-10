public class Thief : Job {

	public Thief(BaseCharacter bc){
		owner = bc;
		Name = "Thief";

		actions.Add (new Bash (owner));
		actions.Add (new Steal (owner));

	}
}
