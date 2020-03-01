using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class healthManager : MonoBehaviour {

	int[] scoreArray = { 10 , 30 , 60 , 100 , 150 , 210 , 280 };

	int counter = 0;

	
	public static int levelCount = 1;
	public static bool levelFinished = false;
	public static float score = 0f;
	public Text scoreText ;
	//[SerializeField] private healthBarScript healthBarScript;
	public static int scoreVal;
		public static string str = "0";
	public static int scoreNeeded , score_Display = 0;
	void Start(){
		
		scoreText.text = str;
		scoreNeeded =scoreArray[counter];
	}
	void Update(){
		
			// health.setSize(player.shieldHealth);
			// print(player.shieldHealth);
			float val = score ;	
			// int k = Math.Ceiling(scoreText);
			scoreVal = (score_Display);
			// Debug.Log(score);
			str = scoreVal.ToString();
			scoreText.text = str;
			// print("score:" + score);
			if(score == scoreNeeded){
				
				// score = 0;
				scoreVal = scoreNeeded;
				// val = 0;
				//if(levelUp.a == false)
				levelFinished = true;
				// public levelUp l = new levelUp();
				levelCount++;
				increasePoint();
			}	
			
	}

	void increasePoint(){
		player.lifeCount += 1;
		counter++;
		scoreNeeded = scoreArray[counter];
		// print(scoreNeeded);
	}
}
