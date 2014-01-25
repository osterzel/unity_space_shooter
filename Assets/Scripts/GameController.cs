﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText finalScore;
	public GameObject restartGame;
	public int score;

	void Start ()
	{
		restartGame.SetActive(false);
		score = 0;
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Debug.Log("Spawing hazard");
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}


	void updateScore() {
		scoreText.text = "Score: " + score;
	}

	public void addScore(int newScoreValue) {
		score += + newScoreValue;
		updateScore ();
	}

	public void endGame() {
		finalScore.text = "Final Score: " + score;
		scoreText.enabled = false;
		this.StopAllCoroutines ();
		restartGame.SetActive (true);
		//finalScore = "Final Score: " + score;

	}


}