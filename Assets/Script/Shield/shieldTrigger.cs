using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldTrigger : MonoBehaviour {

	Vector3 enemyPos;
	public GameObject effect;
	public void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "enemy"){
			if(ShieldOnOff.shieldOnBool){
				ShieldOnOff.enemyKilled++;
			}
			destroyObject(col.gameObject);
			player.bulletCount += 2;
			healthManager.scoreVal += 2;
		}

	}

	void destroyObject(GameObject enemy) {
		enemyPos = enemy.transform.position;
		Destroy(enemy);
		GameObject g = Instantiate(effect , enemyPos , Quaternion.identity);
		Destroy(g , 3f);

	}
}
