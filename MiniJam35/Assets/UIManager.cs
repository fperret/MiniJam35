﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Sprite musicOn;
	public Sprite musicOff;

	private Text gameOverText;
	private GameObject panel;

	private Text scoreText;
	private Image musicImage;


	private float timeMultiplier;

	private bool musicActivated;

	void Awake()
	{
		panel = transform.Find("Panel").gameObject;
		gameOverText =  panel.transform.Find("gameOver text").GetComponent<Text>();
		scoreText	 = 	transform.Find("backgroundUI").Find("score text").GetComponent<Text>();
		musicImage	 = transform.Find("backgroundUI").Find("Music").GetComponent<Image>();
		
	}

	// Use this for initialization
	void Start () {
		// not used no time to implement
		timeMultiplier = 100.5f;
		musicActivated = true;
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

	public void musicToggle() {
		
		if (musicActivated) {
			musicImage.sprite = musicOff;
		} else {
			musicImage.sprite = musicOn;
		}
		musicActivated = !musicActivated;
	}
}
