using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public UIManager	UIManager;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void gameOver(int loseCause) {
		string gameOverMessage = "game over";
		if (loseCause == 1) {
			gameOverMessage = "death from above";
		}
		else if (loseCause == 2) {
			gameOverMessage = "blub blub blub";
		}
		UIManager.UIGameOver(gameOverMessage);
		Time.timeScale = 0;
	}
}
