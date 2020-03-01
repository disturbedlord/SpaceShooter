using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triPower : MonoBehaviour {

	
	public static bool infiniteAmmo = false;
	public void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "Player"){
			infiniteAmmo = true;
			Destroy(this.gameObject , 0f);
			player.bulletCount += 150;
		}
	}

}