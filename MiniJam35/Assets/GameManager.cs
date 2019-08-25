using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public CameraControl cameraControl;
	public UIManager	UIManager;
	public AudioSource	musicSource;

	public bool gameLive;
	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		gameLive = true;
		timestop();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			UIManager.disableStartPanel();
			Time.timeScale = 1;
		}
	}

	public void gameOver(int loseCause) {
		gameLive = false;
		string gameOverMessage = "game over";
		if (loseCause == 1) {
			gameOverMessage = "death from above";
		}
		else if (loseCause == 2) {
			gameOverMessage = "blub blub blub";
		}
		UIManager.UIGameOver(gameOverMessage);
		Invoke("timestop", 2);
		
	}

	public void timestop() {
		Time.timeScale = 0;
	}

	public void toggleMusic() {
		if (!musicSource.isPlaying) {
			musicSource.Play();
		} else {
			musicSource.Stop();
		}
	}
}
