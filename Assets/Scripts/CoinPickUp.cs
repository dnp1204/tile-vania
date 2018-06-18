﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour {

	[SerializeField] AudioClip coinPickUpSFX;

	void OnTriggerEnter2D(Collider2D other) {
		AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
		Destroy(gameObject);
	}
}