using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raindrop : MonoBehaviour {
	public Cloud cloud; // stores a cloud script from Hierarchy

	/// <summary>
	/// questionE and questionJ are used only when the raindrop is initialized and when the player pushes tab before he/she completes the question.
	/// while dealing with updating the question, use subQuestionE instead.
	/// </summary>
	private string questionJ; // stores a question in Japanese
	private string questionE; // stores a question in English
	private string subQuestionE; // substring from questionE
	private Text textJ; // stores Text Component in Japanese from a raindrop object
	private Text textE; // stores Text Component in English from a raindrop object
	private int index; // stores position of alphabet which a player is typing
	private bool target; // true if a raindrop object is a target
	private Color originalColor;


	// Execution order: Awake() > SetQuestion() > Start(), for some reason..
	void Awake() {
		cloud = GameObject.Find ("Cloud").GetComponent<Cloud> ();
		textJ = transform.Find ("QuestionJ").GetComponent<Text> ();
		textE = transform.Find ("QuestionE").GetComponent<Text> ();
		//index = 0;
		target = false;
		originalColor = gameObject.GetComponent<Renderer> ().material.color;
	}
	// Update is called once per frame
	void Update () {
		//　キーを押しているかどうか
		if (target
			&& Input.anyKeyDown
			&& (!Input.GetMouseButton (0) && !Input.GetMouseButton (1) && !Input.GetMouseButton (2))) {
			//　今見ている文字とキーボードから打った文字が同じかどうか
			if (Input.GetKeyDown (subQuestionE [0].ToString ())) {
				//　正解時の処理を呼び出す
				Correct ();
			} else {
				//　失敗時の処理を呼び出す
				Wrong ();
			}
		}
	}
	private void Correct(){
		if (subQuestionE.Length > 1) {
			subQuestionE = subQuestionE.Substring (1); // Update the question in English with a string whose initial character is omitted from the previous question.
			UpdateQuestion (subQuestionE);
		} else {
			Solved ();
		}
	}
	private void Wrong() {
		Debug.Log ("Wrong");
	}
	public void Solved () {
		cloud.RemoveRaindrop (gameObject); 
		Destroy (gameObject);
	}
	public void SetQuestion (string j, string e) {
		questionJ = j;
		textJ.text = questionJ;
		questionE = e;
		subQuestionE = e;
		textE.text = subQuestionE;
	}
	public void UpdateQuestion (string e) {
		textE.text = subQuestionE;
	}
	public void RestoreQuestion () {
		textE.text = questionE;
	}
	public void TurnOnTarget () {
		target = true;
		gameObject.GetComponent<Renderer> ().material.color = new Color (1, 0, 0, 1); // red
	}
	public void TurnOffTarget() {
		target = false;
		gameObject.GetComponent<Renderer> ().material.color = originalColor;
	}
}
