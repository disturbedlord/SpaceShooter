using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter1 : MonoBehaviour {

	private GameObject target;
	private Rigidbody2D rb;
	Vector2 pos;
	float time = 0f;
	public GameObject bullet;
	public Vector3 offset;
	public Transform gunPos;
	void Start(){
		target = GameObject.FindWithTag("Player");
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		pos.x = target.transform.position.x;
		pos.y = target.transform.position.y;
		time += Time.deltaTime;

		if(time > 3f){
			createBullet();
			time = 0f;
		}
	}
	void FixedUpdate () {
		
		Vector2 lookDir = target.transform.position - transform.position - offset ;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;
	}

	void createBullet(){
		GameObject bulletClone = Instantiate(bullet , new Vector3(gunPos.position.x ,gunPos.position.y , gunPos.position.z) , transform.rotation);
		Destroy(bulletClone , 3f);
	}

}
