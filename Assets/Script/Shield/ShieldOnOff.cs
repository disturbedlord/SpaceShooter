using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldOnOff : MonoBehaviour {

	public static bool shieldOnBool = false;
	public Transform shieldButton;
	public GameObject shieldUp , shieldDown;
	public static int enemyKilled = 0;
	float time = 0f;
	bool on = false;
	public void shieldOn(){
		Debug.Log("clicked");
		if(!on){
			shieldUp.SetActive(true);
			shieldDown.SetActive(true);
			on= true;
			enemyKilled = 0;
			shieldOnBool = true;
		}
	}

	void Update(){

		
		if(on){
			time += Time.deltaTime;
			if(time > 3f){
				
				// time = 0f;
				shieldUp.SetActive(false);
				shieldDown.SetActive(false);
				shieldOnBool = false;
				
			}
			shieldButton.GetComponent<Button>().interactable = false;

		}
		if(time > 10f || enemyKilled > 10){
			on = false;
			time = 0f;
			shieldButton.GetComponent<Button>().interactable = true;
		}

	}

}