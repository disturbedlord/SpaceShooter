using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour {

	public static bool generatePowerUps = false;
	void Update () {
		int num = Random.Range(1 , 10);

		if(num > 8){
			generatePowerUps = true;
		}

		/* 
		* this is for generating powerUps script 
		* if generatePowerUps == true an enemy will die and generate powerups at  random
		*/
	
	}
}
