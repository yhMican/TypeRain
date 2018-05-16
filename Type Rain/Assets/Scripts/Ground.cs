using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		//levelManager = GameObject.FindObjectOfType<LevelManager> ();
		//levelManager.LoadLevel ("Lose Screen");
		Destroy(trigger.gameObject);
	}

}
