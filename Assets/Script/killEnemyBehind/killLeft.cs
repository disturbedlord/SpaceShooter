using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	Collider2D col;
	
	void Start(){
		col = GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void Update () {
		if(enemySpawner.pos == 3){
			col.isTrigger = true;
		}
		else col.isTrigger = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "enemy"){
			Destroy(other.gameObject);
		}
	}

}
