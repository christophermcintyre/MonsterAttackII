using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public float forwardSpeed;
	public float rotateSpeed;
	private CharacterController playerController;
	private GameMenu gameMenu;
	private MenuManager menuManager;

	public GameObject marker;
	public GameObject sand_fort;
	public GameObject sand_wall;

	//public List<GameObject> constructions = new List<GameObject>();
	//public GameObject lastActive;
	public List<GameObject> activeObjects = new List<GameObject>();
	public List<ItemPickup> activeItems = new List<ItemPickup>();

	
	public Text stickText;
	public int sticks;

	void Start () {

		playerController = GetComponent<CharacterController> ();
		gameMenu = GameObject.FindGameObjectWithTag ("GameMenu").GetComponent<GameMenu>();
		menuManager = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<MenuManager> ();
	}

	void Update () {

		Movement ();
		AnimationControl ();
		KeyActions ();

		stickText.text = "Sticks: " + sticks;	
	}

	void Movement(){

		Vector3 forward = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * forwardSpeed;
		transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * rotateSpeed * Time.deltaTime, 0));
		playerController.Move (forward * Time.deltaTime);
		playerController.SimpleMove (Physics.gravity);
	}

	void KeyActions(){

		if (Input.GetKey ("i")) {
			menuManager.showMenu(gameMenu);
		}

		if (Input.GetKeyDown ("m") && (sticks > 0)) {
			GameObject m = (GameObject)Instantiate(marker);
			//constructions.Add(m);
			m.transform.position = this.transform.position;
			m.transform.rotation = this.transform.rotation;
			sticks -= 1;
		}

		if (Input.GetKeyDown ("f") && (sticks > 0)) {
			GameObject m = (GameObject)Instantiate(sand_fort);
			//constructions.Add(m);
			m.transform.position = this.transform.position;
			m.transform.rotation = this.transform.rotation;
			sticks -= 1;
		}

		if (Input.GetKeyDown ("g")) {
			GameObject m = (GameObject)Instantiate(sand_wall);
			//constructions.Add(m);
			m.transform.position = this.transform.position;
			m.transform.rotation = this.transform.rotation;
			//sticks -= 1;
		}
		
		if (Input.GetKeyDown ("x") && activeObjects.Count > 0) {
			//constructions.Remove(lastActive);
			Destroy(activeObjects[0]);
			activeObjects.Remove(activeObjects[0]);
			sticks +=1;
		}

		if (Input.GetKeyDown ("p") && activeItems.Count > 0) {
			//constructions.Remove(lastActive);
			Destroy(activeItems[0]);
			Destroy(activeItems[0].gameObject);

			activeItems.Remove(activeItems[0]);
			sticks +=1;
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
