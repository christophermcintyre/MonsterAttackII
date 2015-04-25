using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JobList : MonoBehaviour {

	public List<Job> jobs;
	public JobIndex currentJob;

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

		jobs = new List<Job> ();

		jobs.Add (new Brawler());
		jobs.Add (new Thief ());	
		jobs.Add (new Warrior ());	
		jobs.Add (new Musician ());
		jobs.Add (new BlackMage ());
		jobs.Add (new DarkKnight ());
		jobs.Add (new WhiteMage ());
		jobs.Add (new Sorcerer ());
		jobs.Add (new Shepherd ());
	
	}

	public void changeJob(int i){	
		currentJob = (JobIndex)i;
	}

	public Job getCurrentJob(){
		return jobs[(int)currentJob];
	}
}
