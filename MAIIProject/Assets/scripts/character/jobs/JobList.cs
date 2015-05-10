using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JobList : MonoBehaviour {

	public List<Job> jobs;
	public JobIndex currentJob;

	private BaseCharacter owner;

	public enum JobIndex {
		BRAWLER,
		THIEF,
		WARRIOR,
		MUSICIAN,
		BLACK_MAGICIAN,
		DARK_KNIGHT,
		WHITE_MAGICIAN,
		SORCERER,
		SHEPHERD
	}

	public void init () {

		owner = GetComponent<BaseCharacter> ();

		jobs = new List<Job> ();

		jobs.Add (new Brawler(owner));
		jobs.Add (new Thief (owner));	
		jobs.Add (new Warrior (owner));	
		jobs.Add (new Musician (owner));
		jobs.Add (new BlackMage (owner));
		jobs.Add (new DarkKnight (owner));
		jobs.Add (new WhiteMage (owner));
		jobs.Add (new Sorcerer (owner));
		jobs.Add (new Shepherd (owner));
	
	}

	public void changeJob(int i){	
		currentJob = (JobIndex)i;
	}

	public Job getCurrentJob(){
		return jobs[(int)currentJob];
	}
}
