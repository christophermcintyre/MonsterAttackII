using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

	public GameObject target;

	public float moveSpeed;
	public float rotateSpeed;
	public float distance;

	public bool close;
	private CharacterController playerController;


	void Start () {
		playerController = GetComponent<CharacterController> ();

	}
	
	void Update () {
	
		if (!target)
			return;
		checkDistance ();
		//Movement ();
		tardyMovement ();
		//BasicMovement (); //floaty movement
		//AdvancedMovement (); //gravity but spins too much
		AnimationControl ();
	}

	void checkDistance(){

		if (Vector3.Distance (target.transform.position, transform.position) > distance) {
			close = false;
		} else if (Vector3.Distance (target.transform.position, transform.position) < 2){
			close = true;
		}
	}

	void tardyMovement(){
		if(!close){
			
			Vector3 forward = transform.TransformDirection(Vector3.forward) * moveSpeed;
			Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
			
			transform.rotation = new Quaternion(0,rotation.y,0,rotation.w);
			//transform.position += transform.forward * moveSpeed * Time.deltaTime;
			
			playerController.Move (forward * Time.deltaTime);
			playerController.SimpleMove (Physics.gravity);
			
			animation.CrossFade("Walk");
			
		} else {
			animation.CrossFade("Idle");
		}
		
		playerController.SimpleMove (Physics.gravity);
	}

	void Movement(){

		if(Vector3.Distance (target.transform.position, transform.position) > distance){

			Vector3 forward = transform.TransformDirection(Vector3.forward) * moveSpeed;
			Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));

			transform.rotation = new Quaternion(0,rotation.y,0,rotation.w);
			//transform.position += transform.forward * moveSpeed * Time.deltaTime;

			playerController.Move (forward * Time.deltaTime);
			playerController.SimpleMove (Physics.gravity);

			animation.CrossFade("Walk");

		} else {
			animation.CrossFade("Idle");
		}

		playerController.SimpleMove (Physics.gravity);

	}

	void BasicMovement(){

		if(Vector3.Distance (target.transform.position, transform.position) > distance){			
			
			Vector3 forward = transform.TransformDirection(Vector3.forward) * moveSpeed;

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), rotateSpeed * Time.deltaTime);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
			
			animation.CrossFade("Walk");
			
		} else animation.CrossFade("Idle");
	}

	void AdvancedMovement(){
		
		if(Vector3.Distance (target.transform.position, transform.position) > distance){			
			
			Vector3 forward = transform.TransformDirection(Vector3.forward) * moveSpeed;			
			Vector3 targetDir = target.transform.position - transform.position;
			float angle = Vector3.Angle(targetDir, forward);
			
			transform.Rotate (new Vector3 (0, angle * rotateSpeed * Time.deltaTime, 0));
			playerController.Move (forward * Time.deltaTime);
			playerController.SimpleMove (Physics.gravity);

			animation.CrossFade("Walk");

		} else animation.CrossFade("Idle");
	}

	void AnimationControl(){

		if (Input.GetKey ("j")) {
			animation.Play("Joy");
		}		
	}
}
