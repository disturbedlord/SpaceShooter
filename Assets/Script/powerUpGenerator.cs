using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpGenerator : MonoBehaviour {

	public GameObject powerUp;

	// Update is called once per frame
	void Update () {
		if(healthManager.levelCount > 2){
			findLocation();
		}		
	}

	void findLocation(){
		
	}
}
