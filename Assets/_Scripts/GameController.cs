using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static GameController instance;

	public GameObject enemyCraftPrefab;
	private float speed;
	private float speed2;

	float min = 1.0f;
	float max = 5.0f;
	float targetTime;
	float targetTime2;
	float targetTime3;

	public GameObject enemyCraftPrefab2;

	public Text txtKills;
	public static int killCount;
	public int initkills = 0;
	public Text win;

	public GameObject asteroidPai;
	public Text opening;





	public static bool gameOver;

	private void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		gameOver = false;
	}


	void Start () {

		Destroy (opening,2f);
		win.text = "";


		speed = Random.Range(20f, 50f) * -1;
		speed = -150;

		speed2 = Random.Range(20f, 50f) * -1;
		speed2 = -150;
	
		killCount = initkills;
		txtKills.text = "Kills: " + killCount;
	}

	// Update is called once per frame
	void Update()
	{
		

		txtKills.text = "Kills: " + killCount;

	
		targetTime -= Time.deltaTime;
		targetTime2 -= Time.deltaTime;
		targetTime3 -= Time.deltaTime;


		if (targetTime <= 0.0f) {
			targetTime = Random.Range (min, max);

			Vector3 spawnOffset = new Vector3 (0f, Random.Range (-5f, 5f), 0f);
			var enemy = (GameObject)Instantiate (enemyCraftPrefab,
				            transform.position + spawnOffset, transform.rotation);
			enemy.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (speed, 0f));

			targetTime2 = Random.Range (min, max);

	
		}

		if (targetTime2 <= 0.0f) {
			targetTime2 = Random.Range (min, max);


			Vector3 spawnOffset2 = new Vector3 (0f, Random.Range (-5f, 5f), 0f);
			var enemy2 = (GameObject)Instantiate (enemyCraftPrefab2,
				             transform.position + spawnOffset2, transform.rotation);
			enemy2.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (speed2, 0f));
		}

		if (targetTime3 <= 0.0f) {
			targetTime3 = Random.Range (4f, 5f);

			Vector3 spawnOffset3 = new Vector3 (0f, Random.Range (-5f, 5f), 0f);
			var enemy3 = (GameObject)Instantiate (asteroidPai,
				             transform.position + spawnOffset3, transform.rotation);
			enemy3.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-10f, 0f));
	
		}


		if (gameOver && Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	
		if (killCount >= 15) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}

		if (killCount >= 20) {
			win.text = "You Win!!";
		}
	}





	public static void killTrump ()
	{
			killCount++;

			


	}

	public static void killPence ()
	{
		killCount++;

	}
		
	public static void PlayerDead()
	{
		gameOver = true;
	}


		

}




