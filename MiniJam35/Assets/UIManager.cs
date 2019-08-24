using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private Text gameOverText;
	private GameObject panel;

	private Text scoreText;

	private float timeMultiplier;

	void Awake()
	{
		panel = transform.Find("Panel").gameObject;
		gameOverText =  panel.transform.Find("gameOver text").GetComponent<Text>();
		scoreText	 = 	transform.Find("score text").GetComponent<Text>();
		
	}

	// Use this for initialization
	void Start () {
		timeMultiplier = 100.5f;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = ((int)(Time.time * timeMultiplier)).ToString();
	}

	public void UIGameOver(string gameOverMessage) {
		panel.SetActive(true);
		gameOverText.text = gameOverMessage;
		gameOverText.enabled = true;
	}
}
