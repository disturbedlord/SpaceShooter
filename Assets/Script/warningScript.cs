using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warningScript : MonoBehaviour {

	public static warningScript instance;
	public bool trigger = false;
	public static float timer = 10f;
	public static bool playerDead = false;
	public Text timerText;
	public GameObject warningScreen;

	void Awake(){
		instance = this;
	}

	void Update(){
		if(trigger){
			timer -= Time.deltaTime;
			timerText.text = timer.ToString("F1");

			if(timer <= 0){
				playerDead = true;
				trigger = false;
			}
		}
	}

	public void enterArea(){
		warningScreen.SetActive(true);
		trigger = true;
	}

	public void exitArea(){
		trigger = false;
		warningScreen.SetActive(false);
		timer = 10f;
	}

}
