using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {


	
	public GameObject[] enemy;
	public Transform playerPos;
	public static int rudeCount = 0 , sugarCount = 0;
	public GameObject rude;
	GameObject e;
	
	float timeToSpawn = 0f;
	public static int spawnCount = 0;
	
	public static int pos = 0;
	float rot;

	Vector3 spawnPosition;
	void Update(){
		rot = playerPos.rotation.eulerAngles.z;
		// print(rot);
		if(player.lifeCount > 0)
			spawnLogic();

		if(rot >= 45f && rot < 135 )	pos = 1;
		else if( rot >= 135 && rot < 225) 	pos = 2;
		else if( rot >= 225 && rot < 315)	pos = 3;
		else	pos = 4;

	}

	
	void spawnLogic(){
		bool play = player.playerUnactive;
		timeToSpawn += Time.deltaTime;

		if(spawnCount < 15 ){
			if(timeToSpawn > 0.75 && !play){
				timeToSpawn = 0f;
				spawnEnemy();
			}
		}
	}


	void spawnEnemy(){

		enemyLocation();

		int level = healthManager.levelCount;

		// if(level == 1){
		// 	enemy[0].SetActive(true);
		// 	e = enemy[0];
		// 	rude.SetActive(false);
		// }
		// else if() {
		// 	rude.SetActive(true);
		// }

		switch(level){
			case 1: 
				enemy[0].SetActive(true);
				e = enemy[0];
				Instantiate(e ,	spawnPosition , Quaternion.identity );
				break;
			case 2 :
			case 3 :
				enemy[1].SetActive(true);
				int r = Random.Range(1 , 10);
				if(r > 5){
					e = enemy[1];
				}
				else e = enemy[0];

				Instantiate(e ,	spawnPosition , Quaternion.identity );
				break;
			// case 4 :
			// 	e = enemy[2];
			// 	getFixedLocation();
			// 	Instantiate(e , )


			// 	break;
			
			
			default:
					enemy[1].SetActive(true);
					int rr = Random.Range(1 , 10);
					if(rr > 5){
						e = enemy[1];
					}
					else e = enemy[0];

					Instantiate(e ,	spawnPosition , Quaternion.identity );
					break;

		}

		spawnCount++;
		
	}

	void setActiveFalse(){
		enemy[0].SetActive(false);
		enemy[1].SetActive(false);
		
	}
 
	void getFixedLocation(){
		Vector3 playerCurrentPos = playerPos.position;
		
	}
	

	void enemyLocation(){
		int playerx = (int)playerPos.position.x;
		int playery = (int)playerPos.position.y;
		// int minx = 11 , maxx = 15 , miny = 6 , maxy = 10;
		int xpos = Random.Range(playerx + 11 , playerx + 15);
		int xneg = Random.Range(playerx - 15 ,playerx - 10);
		int ypos = Random.Range(playery + 11 , playery + 15);
		int yneg = Random.Range(playery - 15 ,playery - 11);

		int ran = Random.Range(1 , 5);


		if(ran == 1){
			spawnPosition = new Vector3(xpos , ypos );
		}
		else if(ran == 2 ) {
			spawnPosition = new Vector3(xneg , yneg);
		}
		else if(ran == 3 ){
			spawnPosition = new Vector3(xpos , yneg);
		}
		else if( ran > 3){
			spawnPosition = new Vector3(xneg , ypos);
		}

	}
}
