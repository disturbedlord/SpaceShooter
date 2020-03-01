using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour {

	public float rotateSpeed = 20f;
	public float moveSpeed = 5f;

	float rot;
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3(0 , moveSpeed*Time.deltaTime , 0);
		
		pos += transform.rotation * velocity;
		rot = transform.rotation.eulerAngles.z;
		transform.position = pos;
		// transform.Rotate(0 , 0 , 3 * Time.deltaTime * rotateSpeed);

	}
}
