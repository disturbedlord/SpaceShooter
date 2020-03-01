using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;


public class respawnScript : MonoBehaviour {

	
	// Use this for initialization
	public void respawn(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		player.playerUnactive = false;
		healthManager.score = 0f;
		enemySpawner.spawnCount = 0;
		triggerChecker.playerKilled = false;
		player.bulletCount = 50;
		warningScript.playerDead = false;
		healthManager.levelCount = 1;
		levelScore.counter = 1;
		healthManager.score_Display = 0;
		player.reloadClicked = true;
		player.shieldHealth = 1f;
		player.lifeCount = 3;
		warningScript.timer = 10f;
		player.dead = false;
//		UiOver.instance.hideUi();
	}
}
