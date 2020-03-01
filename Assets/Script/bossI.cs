using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossI : MonoBehaviour {

	float time = 0f;
	bool flickOn = false;
	public Animator flick;
	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "bulletPlayer"){
			Destroy(col.gameObject , 0f);
			flickOn = true;
		}
	}
	void Update(){
		if(flickOn){
			flick.enabled = true;
			time += Time.deltaTime;
				if(time > 0.1f){
					flickOn = false;
					time = 0f;
					flick.enabled = false;
				}
		}
	}
}
