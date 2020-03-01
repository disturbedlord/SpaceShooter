using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_dotScript : MonoBehaviour {

	public GameObject[] dot;
	int maxDot = 2;
	void Update () {
		if(triggerChecker.hideDot == 1){
			hide();
			triggerChecker.hideDot = 0;
		}
		if(triggerChecker.displayDot == 1){
			display();
			triggerChecker.displayDot = 0;
		}
	}

	void hide(){
		dot[maxDot].SetActive(false);
		maxDot--;
	}

	void display(){
		for(int i = 0; i < 3 ; i++)
			dot[i].SetActive(true);
		maxDot = 2;
	}

}
