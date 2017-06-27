using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

	public GameObject carousel;

	public GameObject elephant;
	public GameObject cat;
	public GameObject monkey;

	private string animation;

	private int blinkCounter;

	private bool blinkFlag;
	private bool spinFlag;

	private float spinCurrent;
	private float spinMax;

	//---------------------------------------------------------------------//

	public void hideAnimation(){
		elephant.SetActive (false);
		monkey.SetActive (false);
		cat.SetActive (false);
	}

	public void selectElephant(){
		if (spinFlag == false && blinkFlag== false) {
			if (animation != "elephant") {
				hideAnimation ();
				elephant.SetActive (true);
				animation = "elephant";
			}
		}
	}

	public void selectMonkey(){
		if (spinFlag == false && blinkFlag== false) {
			if (animation != "monkey") {
				hideAnimation ();
				monkey.SetActive (true);
				animation = "monkey";
			}
		}
	}

	public void selectCat(){
		if (spinFlag == false && blinkFlag== false) {
			if (animation != "cat") {
				hideAnimation ();
				cat.SetActive (true);
				animation = "cat";
			}
		}
	}

	//---------------------------------------------------------------------//

	public void BlinkOn(){
		blinkFlag = true;
	}

	public void BlinkOff(){
		blinkFlag = false;
	}

	public void SpinOn(){
		spinFlag = true;
	}

	public void SpinOff(){
		spinFlag = false;
		blinkFlag = false;
	}

	//---------------------------------------------------------------------//

	void Awake() {
		animation = "elephant";
		spinCurrent = 0f;
		spinMax = 110f;
		Application.targetFrameRate = 30;
	}

	// Use this for initialization
	void Start () {
		spinFlag = false;
		blinkFlag = false;
		blinkCounter = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (blinkFlag) {
			blinkCounter++;
			if (blinkCounter > 1) {
				carousel.SetActive (false);
			}
			if (blinkCounter >= 8) { 
				carousel.SetActive (true);
				blinkCounter = 0;
			}
		}
		if (spinFlag) {
			spinCurrent += 2f;
			if (spinCurrent >= spinMax) {
				spinCurrent = spinMax;
			}
			carousel.transform.Rotate (Vector3.up * Time.deltaTime * -spinCurrent);
		} else {
			spinCurrent -= 0.5f;
			if (spinCurrent < 0f) {
				spinCurrent = 0f;
			}
			carousel.transform.Rotate (Vector3.up * Time.deltaTime * -spinCurrent);
		}
	}

}
