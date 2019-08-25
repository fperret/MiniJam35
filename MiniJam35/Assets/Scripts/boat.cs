using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour {

	public ObstacleManager obstacleManager;
	public BackgroundManager backgroundManager;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.Translate(Vector2.up * Time.deltaTime * speed);

		}
		else if (Input.GetKey(KeyCode.DownArrow)) {
			transform.Translate(Vector2.down * Time.deltaTime * speed);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("obstacle")) {
			GameManager.instance.cameraControl.bigScreenShake();
			obstacleManager.enabled = false;
			backgroundManager.enabled = false;
			Invoke("boatGameOver", 1);
		}
	}

	private void boatGameOver() {
		GameManager.instance.gameOver(2);
	}
}
