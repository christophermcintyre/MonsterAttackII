using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void newGame (){
		loadScene ("main");
	}

	public void loadGame(){
	}

	public void loadScene (string scene) {
		Application.LoadLevel (scene);
	}

	public void quitGame (){
		Application.Quit ();
	}

}
