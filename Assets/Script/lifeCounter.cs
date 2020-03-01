using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeCounter : MonoBehaviour {

	public Text lifeCountText;
	void Update(){
		lifeCountText.text = player.lifeCount.ToString();
	}

}
