using UnityEngine;
using System.Collections;

public class DamagePopUp : MonoBehaviour {

	private Vector3 position;
	private Vector3 screenPointPosition;
	private Camera cameraHold;
	private string text;

	// Use this for initialization
	void Start () {
	
		cameraHold = Camera.main;
		screenPointPosition = cameraHold.WorldToScreenPoint (position);


	}
	
	// Update is called once per frame
	void Update () {

		screenPointPosition.y -= 1;
	
	}

	public static void ShowMessage(string texto, Vector3 position) {
		var newInstance = new GameObject ("Damage Pop-Up");
		var damagePopUp = newInstance.AddComponent<DamagePopUp> ();
		damagePopUp.position = position;
		damagePopUp.text = texto;
	}

	void OnGUI(){
		var screenPX = cameraHold.WorldToScreenPoint (position);
		GUI.Label(new Rect(screenPX.x, screenPointPosition.y, 150, 20), text);
		Destroy(gameObject, 1);

	}

}
