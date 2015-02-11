using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

	public GameObject target;

	public float moveSpeed;
	public float rotateSpeed;
	public float distance;

	void Start () {

	}
	
	void Update () {
	
		if (!target)
			return;
		Movement ();
		AnimationControl ();
	}

	void Movement(){

		if(Vector3.Distance (target.transform.position, transform.position) > distance){
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), rotateSpeed * Time.deltaTime);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		animation.CrossFade("Walk");
		} else {
		animation.CrossFade("Idle");
		}



	}

	void AnimationControl(){

		if (Input.GetKey ("j")) {
			animation.Play("Joy");
		}		
	}
}
