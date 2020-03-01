using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUp : MonoBehaviour {

	//public static bool a = false;
	[SerializeField]
	private Animator level;
	public GameObject levelGB;
	bool displayed = false;

	float t = 0f;
	void Start(){
		levelGB.SetActive(false);
	}
	void Update(){
		// levelGB.SetActive(false);

		if(healthManager.levelFinished){
			levelGB.SetActive(true);
			level.SetTrigger("level");
			healthManager.levelFinished = false;
			displayed = true;
		}

		if(displayed){

			t += Time.deltaTime;
			if(t > 1) {
				levelGB.SetActive(false);
				t = 0f;
				displayed = false;
			}

		}

	}
}
