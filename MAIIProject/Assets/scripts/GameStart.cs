﻿using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public Player player = null;
	// Use this for initialization
	void Start () {
		player = Player.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
