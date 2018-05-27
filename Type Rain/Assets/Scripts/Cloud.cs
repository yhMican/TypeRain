using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour {

	private int width = Screen.width;

	private string[] test = {"テスト", "こんにちは", "菓子"};
	private string[] testAlpha = { "tesuto", "konnnitiha", "kasi" };
	private Text UIJ;
	private Text UIR;

	public GameObject raindrop;
	public float RainsPerSeconds;

	public GameObject parent;

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
		GameObject rainDrop = Instantiate (raindrop, 
			new Vector3(Random.Range(- width/100f, width/100f), transform.position.y, transform.position.z), 
			Quaternion.identity);
		rainDrop.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -2.0f, 0);
		rainDrop.transform.parent = parent.transform;
	}

}
