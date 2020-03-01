using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiOver : MonoBehaviour {

	public static UiOver instance;

	public GameObject gameOverUi;

	public void displayUi(){
		gameOverUi.SetActive(true);
	}

	public void hideUi(){
		gameOverUi.SetActive(false);
	}
	
}
