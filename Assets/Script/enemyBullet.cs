using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {

	// Use this for initialization
	public GameObject bullet;
	public GameObject host;
	Rigidbody2D rb;
	float rot;
	public float speed;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rot = host.transform.rotation.eulerAngles.z;
		//Vector3 v = new 
		//rb.AddForce(speed * Time.deltaTime);
		

	}
}
