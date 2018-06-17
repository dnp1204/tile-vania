using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] float runSpeed = 5f;
	[SerializeField] float jumpSpped = 5f;

	Rigidbody2D myRigidBody;
	Animator myAnimator;
	Collider2D myCollider2D;

	void Start() {
		myRigidBody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		myCollider2D = GetComponent<Collider2D>();
	}

	void Update() {
		Run();
		FlipSprite();
		Jump();
	}

	private void Run() {
		float controlThrow = Input.GetAxis("Horizontal"); // value is between -1 to +1
		Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
		myRigidBody.velocity = playerVelocity;

		bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
		myAnimator.SetBool("Running", playerHasHorizontalSpeed);
	}

	private void Jump() {
		if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
			return;
		}

		if (Input.GetButtonDown("Jump")) {
			Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpped);
			myRigidBody.velocity += jumpVelocityToAdd;
		}
	}

	private void FlipSprite() {
		bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
		if (playerHasHorizontalSpeed) {
			transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
		}
	}
}