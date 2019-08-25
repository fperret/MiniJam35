using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour {

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
		Debug.Log("collision boat");
		if (other.gameObject.CompareTag("obstacle"))
			GameManager.instance.gameOver(2);
	}
}
