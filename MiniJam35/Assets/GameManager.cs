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

	public void gameOver() {
		UIManager.UIGameOver();
	}
}
