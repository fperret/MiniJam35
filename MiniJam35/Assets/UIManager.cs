using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private Text gameOverText;
	private GameObject panel;

	void Awake()
	{
		gameOverText =  transform.Find("Panel").Find("gameOver text").GetComponent<Text>();
		panel = transform.Find("Panel").gameObject;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UIGameOver() {
		panel.SetActive(true);
		gameOverText.enabled = true;
	}
}
