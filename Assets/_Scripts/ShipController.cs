using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

	public float speed = 10f;
	public Transform bulletSpawn;
	public GameObject bulletPrefab;
	private Rigidbody2D rb;
	public Text txtAmmo;
	private int ammoCount;
	public int initAmmo = 200;

	public Text txtLives;
	private int livesCount;
	public int initLives = 3;

	public GameObject explode;
	public Transform boomSpawn;
	public AudioSource fired;

	public Text ending;


	// Use this for initialization
	void Start () {
		ending.text = "";

		ammoCount = initAmmo;
		txtAmmo.text = "Ammo: " + ammoCount;
		rb = gameObject.GetComponent<Rigidbody2D>();

		livesCount = initLives;
		txtLives.text = "Lives: " + livesCount;

		Debug.Log (livesCount);
	}

	// Update is called once per frame
	void FixedUpdate() {
		

		float moveH = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");

		// Debug.Log ("Horizontal: " + moveH);
		// Debug.Log ("Vertical: " + moveV);

		Vector2 motion = new Vector2(moveH, moveV);

		rb.AddForce(motion * speed);


		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
			//Debug.Log ("Fire!");
		}

	}


	void Fire()
	{
		if(ammoCount > 0) { 
			ammoCount--;
			txtAmmo.text = "Ammo: " + ammoCount;

			var bullet = (GameObject) Instantiate(bulletPrefab,
				bulletSpawn.position, bulletSpawn.rotation);

			Vector2 bulletMotion = new Vector2(10f, 0f);
			bullet.GetComponent<Rigidbody2D>().AddForce(bulletMotion * 30);
			Destroy(bullet, 2f);
		}
	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.tag.Equals ("MainCamera")) {
			rb.velocity = Vector2.zero;
		}

		if (other.tag.Equals ("enemyBullet") || (other.tag.Equals ("enemy")) || (other.tag.Equals ("asteroid"))) {
			livesCount--;
			txtLives.text = "Lives: " + livesCount;
			var explosion = (GameObject)Instantiate (explode, boomSpawn.position, boomSpawn.rotation);
			fired.Play ();
		
			if (livesCount <= 0) {
				Destroy (gameObject);
				GameController.PlayerDead ();
				ending.text = "Game over! :("; 
			}

		}
	}
}

