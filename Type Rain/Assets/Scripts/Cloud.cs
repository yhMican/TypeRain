﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour {

	private int width = Screen.width;
	private string[] test = {"テスト", "こんにちは", "菓子"};
	private string[] testE = { "tesuto", "konnnitiha", "kasi" };

	public GameObject raindropPrefab;
	public float RainsPerSecond;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float probability = Time.deltaTime * RainsPerSecond;
		if (Random.value < probability) {
			Rain ();
		}
	}

	void Rain () {
		GameObject raindrop = Instantiate (raindropPrefab, 
			new Vector3(Random.Range(- width/100f, width/100f), transform.position.y, transform.position.z), 
			Quaternion.identity);
		raindrop.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -2.0f, 0);
		raindrop.transform.parent = transform;
	}

}
