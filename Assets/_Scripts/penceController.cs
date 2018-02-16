using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class penceController : MonoBehaviour {

	public float speed = 5f;
	public Transform enemyBulletSpawn;
	public GameObject enemyBulletPrefab;
	private Rigidbody2D rb;
	private float timeElapsed;

	public GameObject impact;


	// Use this for initialization
	void Start () {}



	// Update is called once per frame
	void Update ()
	{

		timeElapsed += Time.deltaTime;
		if (timeElapsed % 2 < 0.02) {
			Fire ();

		}
	}

	void Fire ()
	{
		var enemyBullet = (GameObject)Instantiate (enemyBulletPrefab,
			enemyBulletSpawn.position, enemyBulletSpawn.rotation);

		Vector2 bulletMotion = new Vector2 (7f, 0f);
		enemyBullet.GetComponent<Rigidbody2D> ().AddForce (-bulletMotion * 30);
		Destroy (enemyBullet, 2f);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag.Equals ("playerBullet")) {


			var sound = (GameObject)Instantiate (impact);
			Destroy (gameObject);

			GameController.killPence ();


		}

	}

}


