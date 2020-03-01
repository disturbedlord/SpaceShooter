using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rudeTriggerScript : MonoBehaviour {

	public GameObject effectSmall , powerUps;
	
	Vector3 lastPos;
	Vector3 pos;
	bool ranOnce = false;
	float t = 0f;
	GameObject effect;
	void Update(){
		t += Time.deltaTime;
		if(t > 2 && player.lifeCount == 0){
			if(!ranOnce){
				
				Destroy(transform.parent.gameObject , 4f);
				effect = Instantiate(effectSmall , transform.position , Quaternion.identity);
					
					ranOnce = true;
			}
			t = 0;
		}
		Destroy(effect , 4f);
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "bulletPlayer"){
			if(ShieldOnOff.shieldOnBool){
				ShieldOnOff.enemyKilled++;
			}
				pos = transform.parent.position;	
			Destroy(transform.parent.gameObject);
			healthManager.score += 1.0f;
			healthManager.score_Display  += 1;
			Destroy(col.gameObject);
			player.bulletCount += 2;
			enemySpawner.spawnCount--;
			healthManager.str = "0";
			GameObject g = Instantiate(effectSmall , transform.position , Quaternion.identity);
			Destroy(g , 3f);

			if(healthManager.levelCount > 2){
				int ran = Random.Range(1 , 5);
				if(ran % 2 == 0){
					generatePowerUps();
				}
			}

		}
		else if(col.gameObject.tag == "Player"){
			
			if(player.eachLifeCount > 1){	
					player.eachLifeCount--;
					triggerChecker.hideDot = 1;
				}
				else {
					player.lifeCount--;
					player.eachLifeCount = 3;
					if(player.lifeCount != 0)
					triggerChecker.displayDot = 1;
				}
				
				if(player.lifeCount == 0){
					player.playerUnactive = true;
					triggerChecker.hideDot = 1;
				}
				else{
				
					player.dead = true;
				}
			
			Destroy(transform.parent.gameObject);
			GameObject g = Instantiate(effectSmall , transform.position , Quaternion.identity);
			Destroy(g , 3f);

		}
	}

	void generatePowerUps(){
		GameObject powerups = Instantiate(powerUps , lastPos , Quaternion.identity);
	}

}
