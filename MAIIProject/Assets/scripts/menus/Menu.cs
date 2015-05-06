using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Player player;

	private Animator animator;
	private CanvasGroup canvasGroup;
	public BaseCharacter activeCharacter;
	public MenuManager menuManager;
	
	public bool IsOpen{
		get { return animator.GetBool ("IsOpen"); }
		set { animator.SetBool ("IsOpen", value); }
	}

	public void Awake(){
		player = (Player)FindObjectOfType (typeof(Player));
		menuManager = (MenuManager)FindObjectOfType (typeof(MenuManager));
		animator = GetComponent<Animator> ();
		canvasGroup = GetComponent<CanvasGroup> ();
		
		var rect = GetComponent<RectTransform> ();
		rect.offsetMax = rect.offsetMin = new Vector2 (0, 0);		
	}

	public virtual void open(){}

	public virtual void close(){}

	public virtual void refresh(){}

	public void selectCharacter(int characterIndex) {		
		activeCharacter = player.playerParty[characterIndex];		
	}

	//public void DisplaySlot(EquipmentSlot displaySlot){

		//slot = displaySlot;
	//}

	public void Update(){
		
		if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
			canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
		} else {
			canvasGroup.blocksRaycasts = canvasGroup.interactable =  true;
		}
	}
}
