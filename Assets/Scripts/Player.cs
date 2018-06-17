using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] float runSpeed = 5f;
	[SerializeField] float jumpSpped = 5f;
	[SerializeField] float climbSpeed = 5f;

	Rigidbody2D myRigidBody;
	Animator myAnimator;
	CapsuleCollider2D myBodyCollider;
	BoxCollider2D myFeet;
	float gravityAtStart;

	void Start() {
		myRigidBody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		myBodyCollider = GetComponent<CapsuleCollider2D>();
		myFeet = GetComponent<BoxCollider2D>();
		gravityAtStart = myRigidBody.gravityScale;
	}

	void Update() {
		Run();
		Jump();
		ClimbLadder();
		FlipSprite();
	}

	void Run() {
		float controlThrow = Input.GetAxis("Horizontal"); // value is between -1 to +1
		Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
		myRigidBody.velocity = playerVelocity;

		bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
		myAnimator.SetBool("Running", playerHasHorizontalSpeed);
	}

	void Jump() {
		if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
			return;
		}

		if (Input.GetButtonDown("Jump")) {
			Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpped);
			myRigidBody.velocity += jumpVelocityToAdd;
		}
	}

	void ClimbLadder() {
		if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing"))) {
			myAnimator.SetBool("Climbing", false);
			myRigidBody.gravityScale = gravityAtStart;
			return;
		}

		float controlThrow = Input.GetAxis("Vertical");
		Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
		myRigidBody.velocity = climbVelocity;
		myRigidBody.gravityScale = 0f;

		bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
		myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
	}

	void FlipSprite() {
		bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
		if (playerHasHorizontalSpeed) {
			transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
		}
	}
}