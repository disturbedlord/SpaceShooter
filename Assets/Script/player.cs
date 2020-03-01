using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class player : MonoBehaviour {

	public Renderer playerPic;
	public float flashCounter;
	public float flashLength = 0.1f;
	int countFlashes = 0;

	public static float shieldHealth = 1f;
	[SerializeField] Text bulletCountText;
	public static int bulletCount = 50;
	public static int eachLifeCount = 3;
	public static bool reloadClicked = false;
	public static bool playerUnactive = false;
	public Text lifeText;
	// gun Position's Start
	public Transform gunPositionSingleMode;	
	public Transform gunPositionDoubleMode1 , gunPositionDoubleMode2;
	public GameObject effect;
	// gun Position's End
	GameObject clone , clone1;
	public Animator reviveAnim;
	private Rigidbody2D  rb;
	public GameObject bullet;
	public Joystick movementJoystick , viewJoystick;
public float startMoveSpeed = 5f;
	private float moveSpeed;
	
	public Text scoreDisplay;
	public static Vector2 Position;
	public float moveSmooth = .3f;
	// private Animator  anim;
	public GameObject gameOverUi;
	Vector2 velocity = Vector2.zero;
	Vector2 movement = Vector2.zero;
	float horizontalView , verticalView;
	public float timebwShoots = 0.5f;
	public static bool dead = false;
	public static int lifeCount = 3;
	float t = 0f;
	Vector2 duplicateView;
	float time = 0f;
	float shootTime = 0f;
	Vector3 pos;
	Vector2 view;
	int level;
	bool bulletShot = false;
	bool joystickReset = false;
	bool ranOnce = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		pos = transform.position;
		gameOverUi.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if( warningScript.playerDead && !ranOnce){
			ranOnce = true;
			DestroyObject();
		}
		level = healthManager.levelCount;
		duplicateView = view;
		if(viewJoystick.Horizontal == 0f && viewJoystick.Vertical == 0f){
			view.x = horizontalView;
			view.y = verticalView;
			joystickReset = true;
		}else {
			view.x = viewJoystick.Horizontal;
			view.y = viewJoystick.Vertical;
			joystickReset = false;
		}
				
		movement.x = movementJoystick.Horizontal;
		movement.y = movementJoystick.Vertical;
		moveSpeed = startMoveSpeed;
	
		// Debug.Log(view);

		// Debug.Log(pos.x);
		horizontalView = view.x;
		verticalView = view.y;
		// Debug.Log(horizontalView);

		if(view.x >= 0.7f && view.y <= 0.7f || view.x <= 0.7f && view.y <= -0.7f){
			pos = transform.position;
			if(bulletShot == false && !joystickReset && bulletCount!= 0)
				shootBullet();
			
		}
		else if(view.x <= 0.7f && view.y >= 0.7f || view.x <= -0.7f && view.y >=-0.7f ){
			pos = transform.position;
			if(bulletShot == false && !joystickReset && bulletCount!= 0)
				shootBullet();
			
		}

		shootTime += Time.deltaTime;

		if(shootTime > timebwShoots){
			bulletShot = false;
			shootTime = 0f;

		}

		if(dead){
			// time += Time.deltaTime;
			// 		if(time < 1f){
			// 			playerPic.enabled = false;
			// 		}
			// 		else {
			// 			time = 0f;
			// 			// reviveAnim.enabled = false;
			// 			dead = false;
						
			// 		}

			deathFunc();
		
		}
		if(playerUnactive || lifeCount == 0 || warningScript.timer <= 0){
			lifeText.text = lifeCount.ToString();
			gameObject.SetActive(false);
			
			gameOverUi.SetActive(true);
			scoreDisplay.text = healthManager.scoreVal.ToString();

			
			
		}

		if(reloadClicked){
			gameOverUi.SetActive(false);
			reloadClicked = false;
		}

		bulletCountText.text = bulletCount.ToString();

	}

///			VALUE SHOULD BE GREATER THAN OR EQUAL = 7
	private void FixedUpdate()
	{
	
		Vector2 desiredVelocity = movement * moveSpeed;
		rb.velocity = Vector2.SmoothDamp(rb.velocity, desiredVelocity, ref velocity, moveSmooth);


		Vector2 lookDir = view ;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;

		Position = rb.position;
	}

	void shootBullet(){

		switch(level){
		
		case 1:
			clone = Instantiate(bullet , new Vector3(gunPositionSingleMode.position.x , gunPositionSingleMode.position.y , gunPositionSingleMode.position.z) , transform.rotation);
			bulletShot = true;	
			Destroy(clone , 7f);	
			bulletCount--;
			break;

		case 2:
			clone = Instantiate(bullet, new Vector3(gunPositionDoubleMode1.position.x , gunPositionDoubleMode1.position.y , gunPositionDoubleMode1.position.z) , transform.rotation);
			clone1 = Instantiate(bullet, new Vector3(gunPositionDoubleMode2.position.x , gunPositionDoubleMode2.position.y , gunPositionDoubleMode2.position.z) , transform.rotation);

			bulletShot = true;	
			Destroy(clone , 7f);	
			bulletCount -= 2;
			break;
		case 3:
		default:

			if(triPower.infiniteAmmo){
				
				clone = Instantiate(bullet , new Vector3(gunPositionSingleMode.position.x , gunPositionSingleMode.position.y , gunPositionSingleMode.position.z) , transform.rotation);
				timebwShoots = 0.025f;
				bulletShot = true;	
				Destroy(clone , 5f);	
				bulletCount -= 1;
				t += Time.deltaTime;
				if(t > 3){
					t = 0f;
					triPower.infiniteAmmo = false;
					timebwShoots = 0.5f;
					
				}
				
			}
			else {
				clone = Instantiate(bullet, new Vector3(gunPositionDoubleMode1.position.x , gunPositionDoubleMode1.position.y , gunPositionDoubleMode1.position.z) , transform.rotation);
				clone1 = Instantiate(bullet, new Vector3(gunPositionDoubleMode2.position.x , gunPositionDoubleMode2.position.y , gunPositionDoubleMode2.position.z) , transform.rotation);
				bulletShot = true;	
				Destroy(clone , 7f);	
				bulletCount -= 2;
			}
			break;
		}
	}

	void DestroyObject(){
		ranOnce = false;
		GameObject g = Instantiate(effect , transform.position , Quaternion.identity);
		Destroy(g , 3f);
		gameObject.SetActive(false);
	}

	void deathFunc(){
		if(countFlashes <= flashCounter){
				time += Time.deltaTime;
				playerPic.enabled = false;
				
				if(time > flashLength){
					playerPic.enabled = true;
					time = 0f;
				}
				countFlashes++;
				deathFunc();
			}
			else
			{
				countFlashes = 0;
				dead = false;
				time = 0f;
				playerPic.enabled = true;
			}
	}


	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "bulletEnemy"){
			print("bullet");
			eachLifeCount-- ; 
			deathFunc();
		}
	}
}