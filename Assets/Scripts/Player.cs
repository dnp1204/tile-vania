﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] float runSpeed = 5f;

	Rigidbody2D myRigidBody;

	void Start() {
		myRigidBody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		Run();
		FlipSprite();
	}

	private void Run() {
		float controlThrow = Input.GetAxis("Horizontal"); // value is between -1 to +1
		Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
		myRigidBody.velocity = playerVelocity;
	}

	private void FlipSprite() {
		bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
		if (playerHasHorizontalSpeed) {
			transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
		}
	}
}