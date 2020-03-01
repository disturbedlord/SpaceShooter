using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameOverScript : MonoBehaviour {

	public Text scoretext;

	void LateUpdate(){
		scoretext.text = healthManager.scoreVal.ToString();
	}
}
