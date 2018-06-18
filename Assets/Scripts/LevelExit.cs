using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

	[SerializeField] float LevelLoadDelay = 2f;
	[SerializeField] float LevelExitSlowMoFactor = 0.2f;

	void OnTriggerEnter2D(Collider2D other) {
		StartCoroutine(LoadNextLevel());
	}

	IEnumerator LoadNextLevel() {
		Time.timeScale = LevelExitSlowMoFactor;
		yield return new WaitForSecondsRealtime(LevelLoadDelay);
		Time.timeScale = 1;

		int currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScenceIndex + 1);
	}
}