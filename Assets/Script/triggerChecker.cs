using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerChecker : MonoBehaviour {

	public Animator playerRevive;
	int a = 10;
	float moveSpeed = 2f;
	Vector3 pos;
	public static int hideDot = 0 , displayDot = 0;
	float t = 0f;
	bool ranOnce = false;
	public static bool playerKilled = false;
	public GameObject effectSmall , powerUps;
	float time = 0f;
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

	Vector3 lastPos;
	public void OnTriggerEnter2D(Collider2D col){
		lastPos = gameObject.transform.position;

		if(col.gameObject.tag == "bulletPlayer"){	
			if(ShieldOnOff.shieldOnBool){
				ShieldOnOff.enemyKilled++;
			}
			pos = transform.parent.position;	
			Destroy(transform.parent.gameObject);
			Destroy(col.gameObject);
			player.bulletCount += 2;
			enemySpawner.spawnCount--;
			healthManager.str = "0";
			GameObject g = Instantiate(effectSmall , transform.position , Quaternion.identity);
			Destroy(g , 3f);
			healthManager.score += 1.0f; // 0.1f
			healthManager.score_Display  += 1;
			switch(healthManager.levelCount){
				case 1:
					player.bulletCount += 2;		
					break;
				case 2:
					player.bulletCount += 4;
					break;	
			}

			if(healthManager.levelCount > 2){
				int ran = Random.Range(1 , 5);
				if(ran  == 4){
					generatePowerUps();
				}
			}

		}
		else if(col.gameObject.tag == "Player"){
				
				if(player.eachLifeCount > 1){	
					player.eachLifeCount--;
					hideDot = 1;
				}
				else {
					player.lifeCount--;
					player.eachLifeCount = 3;
					if(player.lifeCount != 0)
					displayDot = 1;
				}
				
				if(player.lifeCount == 0){
					player.playerUnactive = true;
					hideDot = 1;
				}
				else{
				
					player.dead = true;
				}
			// Destroy(this.gameObject);
			Destroy(transform.parent.gameObject);
			GameObject g = Instantiate(effectSmall , transform.position , Quaternion.identity);
			Destroy(g , 3f);

		
		}

		

	}

	void generatePowerUps(){
		GameObject powerups = Instantiate(powerUps , lastPos , Quaternion.identity);
	}

}
