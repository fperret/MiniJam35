using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(Vector2.left * Time.deltaTime * speed);

		}
		else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(Vector2.right * Time.deltaTime * speed);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("playerObstacle"))
			GameManager.instance.gameOver(1);
	}
}
