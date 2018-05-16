using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour {

	private string[] test = {"テスト", "こんにちは", "菓子"};
	private string[] testAlpha = { "tesuto", "konnnitiha", "kasi" };
	private Text UIJ;
	private Text UIR;

	public GameObject raindrop;
	public float RainsPerSeconds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float probability = Time.deltaTime * RainsPerSeconds;
		if (Random.value < probability) {
			Rain ();
		}
	}

	void Rain () {
		GameObject rainDrop = Instantiate (raindrop, transform.position, Quaternion.identity);
		rainDrop.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -1.0f, 0);
	}
}
