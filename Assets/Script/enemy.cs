using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	Transform target , fake;
	public float moveSpeed;
	public GameObject effect;
	Transform duplicate;
	float rotateSpeed = 100f;
	int z = 0;
	bool reached = false;
	bool ranOnce = false;
		int y = 0;
	// Update is called once per frame
	void FixedUpdate () {

		try {

			if(!reached)
				fake = GameObject.FindWithTag("PlayerFake").transform;
			else 
				fake = GameObject.FindWithTag("Player").transform;
				
		transform.position = Vector3.MoveTowards(transform.position , fake.position , moveSpeed*Time.deltaTime);

		transform.Rotate(0 , 0 , 3 * Time.deltaTime * rotateSpeed);

		if(fake.position.x > transform.position.x + 30f || fake.position.x < transform.position.x - 30f || fake.position.y > transform.position.y + 30f || fake.position.y < transform.position.y - 30f)
			DestroyObject();
		
		}
		catch {


			transform.position = Vector3.MoveTowards(transform.position , Vector3.forward , moveSpeed*Time.deltaTime);
			
			transform.Rotate(0 , 0 , 3 * Time.deltaTime * rotateSpeed);
		}

		if((player.playerUnactive || warningScript.playerDead || healthManager.levelFinished) && !ranOnce){
			destroyEnemy();
			ranOnce = true;
		}
		// if(healthManager.levelFinished){
		// 	destroyEnemy();
		// 	// healthManager.levelFinished = false;
		// 	ranOnce = true;
		// }

	}

	void OnTriggerEnter2D(Collider2D c){
			 float force = 30;
 
     // If the object we hit is the enemy
     if (c.gameObject.tag == "enemy")
     {
         // Calculate Angle Between the collision point and the player
         Vector3 dir = c.transform.position -  transform.position;
         // We then get the opposite (-Vector3) and normalize it
         dir = -dir.normalized;
         // And finally we add force in the direction of dir and multiply it by force. 
         // This will push back the player
         GetComponent<Rigidbody2D>().AddForce(dir*force);
     }
		
		if(c.gameObject.tag == "PlayerFake"){
			reached = true;
		}


	}

	void DestroyObject(){
		enemySpawner.spawnCount--;
		GameObject g = Instantiate(effect , transform.position , Quaternion.identity);
		Destroy(this.gameObject);
		Destroy(g , 3f);
		ranOnce = false;
	}

	void destroyEnemy(){
		int e = 0;
		if(e == 0){
				Destroy(gameObject);
				e = 1;
		}

		if(e == 1){
		GameObject g = Instantiate(effect , transform.position , Quaternion.identity);
		Destroy(g , 1f);
		}
		ranOnce = false;
	}


}