using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour {
	public GameObject raindropPrefab;
	public float RainsPerSecond;

	private int width = Screen.width;
	private string[] test = {"あ", "テスト", "こんにちは", "菓子"};
	private string[] testE = { "a", "tesuto", "konnnitiha", "kasi" };
	private List<GameObject> rain = new List<GameObject>();
	private int currentTarget = 0;
	//private bool initialRaindropCreated = false; // becomes true when the first raindrop object is created

	// Update is called once per frame
	void Update () {
		float probability = Time.deltaTime * RainsPerSecond;
		if (Random.value < probability) {
			Rain ();
		}
		if (rain.Count > 0 && Input.GetKeyDown (KeyCode.Tab)) {
			rain [currentTarget].GetComponent<Raindrop> ().RestoreQuestion ();
			ChangeTarget ();
		}
	}

	/// <summary>
	/// Rain() instantiates a raindrop object when it is called.
	/// Rain() specifies the initial position, the speed to fall, and the question of a raindrop.
	/// Rain() sets the target of the raindrop on only when there are no raindrop in the game.
	/// </summary>
	private void Rain () {
		GameObject raindrop = Instantiate (raindropPrefab, 
			new Vector3(Random.Range(- width/100f, width/100f), 0, 0), 
			Quaternion.identity);
		raindrop.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -1.0f, 0);
		raindrop.transform.SetParent(transform, false);  // set the parent of raindrop instance to the cloud object
		int randomQuestionNum = Random.Range (0, 4);
		/*Raindrop r = raindrop.GetComponent<Raindrop>();
		r.SetQuestion(test[randomQuestionNum], testE[randomQuestionNum]);*/
		raindrop.GetComponent<Raindrop>().SetQuestion(test[randomQuestionNum],testE[randomQuestionNum]); // equivalent with above two lines? at least works fine
		rain.Add(raindrop);
		if (rain.Count == 1) {
			rain[0].GetComponent<Raindrop> ().TurnOnTarget ();
		}
	}

	/// <summary>
	/// ChangeTarget() is called from Update() when a player pushed tab key, when a raindrop is solved, or when a raindrop is destroyed by Ground.
	/// ChangeTarget() manages targets of rain objects and increments currentTarget by one when there are more than one raindrop, otherwise does nothing.
	/// ChangeTarget() sets currentTarget to 0 if the currentTarget is the index of the last raindrop object in the list "rain".
	/// </summary>
	public void ChangeTarget() {
		if (rain.Count > 1) {
			rain [currentTarget].GetComponent<Raindrop> ().TurnOffTarget ();
			if (currentTarget > rain.Count) {
				currentTarget = 0;
			} else {
				currentTarget++;
			}
			rain [currentTarget].GetComponent<Raindrop> ().TurnOnTarget ();
		}
	}
	/// <summary>
	/// Removes the raindrop.
	/// RemoveRaindrop is called by 
	/// 	Raindrop: Solved()
	/// 	Ground: OnTriggerEnter2D()
	/// </summary>
	/// <param name="r">The red component.</param>
	public void RemoveRaindrop(GameObject r) {
		rain.Remove (r);
		rain [currentTarget].GetComponent<Raindrop> ().TurnOnTarget ();
	}

}
