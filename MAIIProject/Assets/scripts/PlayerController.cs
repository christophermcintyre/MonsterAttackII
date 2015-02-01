using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public float forwardSpeed;
	public float rotateSpeed;
	private CharacterController playerController;


	// Use this for initialization
	void Start () {
		playerController = GetComponent<CharacterController> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		KeyMove ();
		AnimationControl ();


	
	}

	void KeyMove(){

		transform.Translate (transform.forward * forwardSpeed * Input.GetAxis ("Vertical") * Time.deltaTime, Space.World);

		if (Input.GetKey ("d")) {
			transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
		}

		if (Input.GetKey ("a")) {
			transform.Rotate(Vector3.up, Time.deltaTime * -rotateSpeed);
		}


		
	}

	void AnimationControl(){


		Vector3 inputVect = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));


		if (Input.GetKey ("j")) {
			animation.Play("Joy");
		}

		if (inputVect.magnitude == 0 && animation.IsPlaying ("Idle") == false) {
			animation.CrossFade("Idle");
		}

		if (inputVect.magnitude != 0 && animation.IsPlaying("Walk") == false) {
			animation.CrossFade("Walk");
		}

	}

}
