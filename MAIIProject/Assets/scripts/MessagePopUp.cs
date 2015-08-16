using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessagePopUp : MonoBehaviour {

	//private static MessagePopUp instance = null;

	//public static MessagePopUp Instance {
	//	get {
	//		if (instance == null) {
				//Debug.Log("Instancing a new Player");
	//			GameObject go = Instantiate(Resources.Load ("Prefab/MessagePopUp")) as GameObject;
	//			go.name = "MessagePopUp";
	//		}
	//		return instance;
	//	}

	//}


	//public Text displayText;

	//private Vector3 position;
	//private Vector3 screenPointPosition;
	//private Camera currentCamera;
	//private string message;

	//public GameObject popUpPrefab;

	public Transform damageTransform;
	public GameObject damagePrefab;

	public void Awake(){
		//instance = this;
	}

	void Start () {
		//currentCamera = Camera.main;
		//screenPointPosition = currentCamera.WorldToScreenPoint (position);
	}

	void Update () {
		//screenPointPosition.y -= 1;
	}


	public void showMessage(string msg, Transform target){
		//GameObject newInstance = (GameObject)Instantiate(popUpPrefab, target.position, Quaternion.identity );
		//var displayText = newInstance.GetComponent<Text>();
		//displayText.text = msg;
		//newInstance.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform);
		GameObject damageGameObject = (GameObject)Instantiate (damagePrefab, damageTransform.position, damageTransform.rotation);
		damageGameObject.GetComponentInChildren<Text>().text = msg;
	}
}
