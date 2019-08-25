using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	List<string> gameOverMessageValkyrie;
	List<string> gameOverMessageRock;

	// Use this for initialization
	void Start () {
		gameLive = true;
		timestop();
		createValkyrieMessages();
		createRockMessages();
	}
	
	private void createValkyrieMessages() {
		gameOverMessageValkyrie = new List<string>();
		gameOverMessageValkyrie.Add("Death from above");
		gameOverMessageValkyrie.Add("You have been shish kabobed");
		gameOverMessageValkyrie.Add("No valhalla for you");
		gameOverMessageValkyrie.Add("If only you had a helmet");
	}
	private void createRockMessages() {
		gameOverMessageRock = new List<string>();
		gameOverMessageRock.Add("Fishies fishies");
		gameOverMessageRock.Add("Not easy to swim with that helmet");
		gameOverMessageRock.Add("You sank. Remember, the big rock ?");
		gameOverMessageRock.Add("Too bad you don't have Rock Smash");
	}

	// Update is called once per frame
	void Update () {
		if (gameLive) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				UIManager.disableStartPanel();
				Time.timeScale = 1;
			}
		} else {
			if (Input.GetKeyDown(KeyCode.Space)) {
			SceneManager.LoadScene("game");
			}
		}
	}

	public void gameOver(int loseCause) {
		gameLive = false;
		string gameOverMessage = "game over";
		if (loseCause == 1) {
			gameOverMessage = gameOverMessageValkyrie[Random.Range(0, 4)];
		}
		else if (loseCause == 2) {
			gameOverMessage = gameOverMessageRock[Random.Range(0, 4)];
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
