using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarScript : MonoBehaviour {

	float decreaseHealth;
	private Transform Bar;
	// Use this for initialization
	void Start () {
		Bar = transform.Find("bar");
	}
	public void setSize(float val){
		Bar.localScale = new Vector3(val, 1f);
	}
}
