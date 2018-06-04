using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raindrop : MonoBehaviour {

	private string questionJ; // stores a question in Japanese
	private string questionE; // stores a question in English
	private Text textJ;
	private Text textE;


	void Start() {
		textJ = transform.Find ("QuestionJ").GetComponent<Text> ();
		textE = transform.Find ("QuestionE").GetComponent<Text> ();
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void Solved () {
		Destroy (gameObject);
	}

	public void setQuestion (string j, string e) {
		questionJ = j;
		questionE = e;
		textJ.text = questionJ;
		textE.text = questionE;
	}
}
