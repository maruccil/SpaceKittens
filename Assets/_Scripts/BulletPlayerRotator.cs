using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerRotator : MonoBehaviour {


	void Update () {
		
		gameObject.GetComponent<Transform>().Rotate(
			new Vector3(0f, 0f, 3f));
		
		//body.AddForce (transform.right * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals ("boundary")){
			Destroy (gameObject);
	}

		if (other.tag.Equals ("enemy")) {
			Destroy (gameObject);

			Destroy (other.gameObject);
	
		}
	}
}