using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {

	public GameObject targetingCursor;

	public BaseCharacter selectedCharacter;


	public void Start(){
		targetingCursor = (GameObject)Instantiate(targetingCursor, GetComponent<Renderer>().transform.position, new Quaternion(0,0,0,0) );
		targetingCursor.SetActive (false);
	}


	void OnMouseEnter(){
		//Debug.Log ("Mouse Enter");
		targetingCursor.SetActive(true);
		targetingCursor.transform.position = GetComponent<Renderer>().transform.position;
	}

	void OnMouseOver(){
		targetingCursor.SetActive(true);
		//selectedCharacter = (BaseCharacter)GetComponent<Renderer>().gameObject;
	}

	void OnMouseExit(){

		targetingCursor.SetActive(false);

	}



}
