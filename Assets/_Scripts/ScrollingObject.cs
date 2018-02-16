﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
	private Rigidbody2D spaceRb2d;
	public float scrollSpeed;

	// Use this for initialization
	void Start () {
		scrollSpeed = -10.25f;
		spaceRb2d = GetComponent<Rigidbody2D> ();
		spaceRb2d.velocity = new Vector2 (scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.gameOver) {
			spaceRb2d.velocity = Vector2.zero;
		}
	}
}
