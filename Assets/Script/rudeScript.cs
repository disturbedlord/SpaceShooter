using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rudeScript : MonoBehaviour {

	GameObject player ,clone;
	public Transform gunPosition;

	Transform target;
	public GameObject bullet;
	Vector2 pos;
	private Rigidbody2D rb;
	float angle , t = 0f;
	public float moveSpeed;
	void Start(){
		player = GameObject.FindWithTag("Player");
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){

			// pos.x = player.transform.position.x;
			// pos.y = player.transform.position.y;
			pos = player.transform.position;
	}
	void FixedUpdate(){


		Vector2 lookDir = pos - rb.position;
		angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;
		if(healthManager.levelCount >= 3)
		{	
			t += Time.deltaTime;
			if(t > 1){
				shootBullet();
				t = 0f;
			}
		}
		try {
		target = GameObject.FindWithTag("Player").transform;
		// bullet = GameObject.FindWithTag("bullet");
		transform.position = Vector3.MoveTowards(transform.position , target.position , moveSpeed*Time.deltaTime);



		if(target.position.x > transform.position.x + 30f || target.position.x < transform.position.x - 30f || target.position.y > transform.position.y + 30f || target.position.y < transform.position.y - 30f)
			DestroyObject();

		}
		catch {


			transform.position = Vector3.MoveTowards(transform.position , Vector3.forward , moveSpeed*Time.deltaTime);


		}


	}

	void shootBullet(){

		clone = Instantiate(bullet ,new Vector3(gunPosition.position.x , gunPosition.position.y , gunPosition.position.z) , transform.rotation);
		// bulletShot = true;
		Destroy(clone , 10f);
		// bulletCount--;
	}

	void DestroyObject(){
		Destroy(gameObject);
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
		
	}

}
