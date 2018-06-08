using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raindrop : MonoBehaviour {

	private string questionJ; // stores a question in Japanese
	private string questionE; // stores a question in English
	private Text textJ; // stores Text Component in Japanese from a raindrop object
	private Text textE; // stores Text Component in English from a raindrop object
	private int index; // stores position of alphabet which a player is typing
	private bool target; // true if a raindrop object is a target
	private int serialNum; // each raindrop object has a unique serial number, which can be reused after the object is destroyed


	// Execution order: Awake() > SetQuestion() > Start(), for some reason..
	void Awake() {
		textJ = transform.Find ("QuestionJ").GetComponent<Text> ();
		textE = transform.Find ("QuestionE").GetComponent<Text> ();
		index = 0;
		target = false;
	}
	// Update is called once per frame
	void Update () {
		//　キーを押しているかどうか
		if (target
			&& Input.anyKeyDown
			&& (!Input.GetMouseButton (0) && !Input.GetMouseButton (1) && !Input.GetMouseButton (2))) {
			//　今見ている文字とキーボードから打った文字が同じかどうか
			if (Input.GetKeyDown (questionE [index].ToString ())) {
				//　正解時の処理を呼び出す
				Debug.Log ("Correct");
				Correct ();
			} else {
				//　失敗時の処理を呼び出す
				Wrong ();
			}
		}
	}
	private void Correct(){
		questionE = questionE.Substring (++index);
		if (questionE == "") {
			Solved ();
		} else {
			SetQuestion (questionJ, questionE);
		}
	}
	private void Wrong() {
		Debug.Log ("Wrong");
	}
	public void Solved () {
		Destroy (gameObject);
	}
	public void SetQuestion (string j, string e) {
		questionJ = j;
		textJ.text = questionJ;
		questionE = e;
		textE.text = questionE;
	}
	public void TurnOnTarget () {
		target = true;
	}
	public void TurnOffTarget() {
		target = false;
	}
	public void AllocateSerialNum(int num) {
		serialNum = num;
	}
}
