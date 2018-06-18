using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour {

	[SerializeField] AudioClip coinPickUpSFX;
	[SerializeField] int pointsForCoinPickup = 100;

	void OnTriggerEnter2D(Collider2D other) {
		FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
		AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
		Destroy(gameObject);
	}
}