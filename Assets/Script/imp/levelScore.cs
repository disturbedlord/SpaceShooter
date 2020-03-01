using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelScore : MonoBehaviour {

	int[] scoreArray = { 10 , 30 , 60 , 100 , 150 , 210 , 280 };
	public static bool ranOnceLevel = false;
	int prev = 0;
	public static int counter = 0;
	// void Update(){
	// 	print(healthManager.levelCount);
	// 	if(healthManager.levelCount != prev){
	// 		prev = healthManager.levelCount;
	// 		ranOnceLevel = false;
	// 		counter++;
	// 	}

	// 	if(healthManager.levelFinished && !ranOnceLevel) {
	// 		counter++;
	// 		healthManager.scoreNeeded = scoreArray[counter];
	// 		ranOnceLevel = true;
	// 	}
	// }

}
