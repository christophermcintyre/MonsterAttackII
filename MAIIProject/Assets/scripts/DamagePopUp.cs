using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamagePopUp : MonoBehaviour {

	private Vector3 position;
	private Vector3 screenPointPosition;
	private Camera currentCamera;
	private string message;

	//public GameObject popupText;


	// Use this for initialization
	void Start () {
	
		currentCamera = Camera.main;
		screenPointPosition = currentCamera.WorldToScreenPoint (position);

	}
	
	// Update is called once per frame
	void Update () {
			screenPointPosition.y -= 1;	
	}

	public static void ShowMessage(string msg, Vector3 pos) {
		var newInstance = new GameObject ("Damage Pop-Up");
		var damagePopUp = newInstance.AddComponent<DamagePopUp> ();
		damagePopUp.message = msg;
		damagePopUp.position = pos;
	}

	void OnGUI(){
		var screenPX = currentCamera.WorldToScreenPoint (position);
		GUI.Label(new Rect(screenPX.x, screenPointPosition.y, 150, 20), message);
		Destroy(gameObject, 1);

	}

}
