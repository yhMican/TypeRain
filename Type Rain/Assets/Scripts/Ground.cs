using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	private LevelManager levelManager;
	private Cloud cloud;

	void Awake () {
		cloud = GameObject.Find ("Cloud").GetComponent<Cloud> ();
	}
	void OnTriggerEnter2D (Collider2D trigger) {
		//levelManager = GameObject.FindObjectOfType<LevelManager> ();
		//levelManager.LoadLevel ("Lose Screen");
		cloud.RemoveRaindrop(trigger.gameObject);
		Destroy(trigger.gameObject);
	}

}
