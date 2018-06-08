using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour {

	private int width = Screen.width;
	private string[] test = {"あ", "テスト", "こんにちは", "菓子"};
	private string[] testE = { "a", "tesuto", "konnnitiha", "kasi" };
	private GameObject[] rain = new GameObject[20];
	private int currentTarget = 0;
	private bool initialRaindropCreated = false;

	public GameObject raindropPrefab;
	public float RainsPerSecond;


	// Update is called once per frame
	void Update () {
		float probability = Time.deltaTime * RainsPerSecond;
		if (Random.value < probability) {
			Rain ();
		}
		if (Input.GetKeyDown (KeyCode.Tab)) {
			ChangeTarget ();
		}
	}

	void Rain () {
		GameObject raindrop = Instantiate (raindropPrefab, 
			new Vector3(Random.Range(- width/100f, width/100f), transform.position.y, transform.position.z), 
			Quaternion.identity);
		raindrop.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -2.0f, 0);
		raindrop.transform.parent = transform;  // set the parent of raindrop instance to the cloud object
		int randomQuestionNum = Random.Range (0, 4);
		/*Raindrop r = raindrop.GetComponent<Raindrop>();
		r.SetQuestion(test[randomQuestionNum], testE[randomQuestionNum]);*/
		raindrop.GetComponent<Raindrop>().SetQuestion(test[randomQuestionNum],testE[randomQuestionNum]); // equivalent with above two lines? at least works fine
		for (int num = 0; num < rain.Length; num++) {
			if (rain [num] == null) {
				rain [num] = raindrop;
				rain [num].GetComponent<Raindrop> ().AllocateSerialNum (num);
			}
		}
		if (!initialRaindropCreated) {
			raindrop.GetComponent<Raindrop> ().TurnOnTarget ();
		}
	}

	void ChangeTarget() {
		rain [currentTarget].GetComponent<Raindrop> ().TurnOffTarget ();
		if (currentTarget > rain.Length) {
			currentTarget = 0;
		} else {
			currentTarget++;
		}
		rain [currentTarget].GetComponent<Raindrop> ().TurnOnTarget ();
	}

}
