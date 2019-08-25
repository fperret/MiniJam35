using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie : MonoBehaviour {

	float speed = 5f;

	enum State {
		IDLE = 0,
		FALLING,
		LANDED,
		LEAVING
	}

	private State currentState;

	private Animator animator;

	// Use this for initialization
	void Start () {
		currentState = State.IDLE;
		animator = GetComponent<Animator>();
	}
	
	public void startFall() {
		currentState = State.FALLING;
	}

	public void land() {
		GameManager.instance.cameraControl.screenShake();
		currentState = State.LANDED;
	}

	// Update is called once per frame
	void Update () {
		if (currentState == State.FALLING) {
			transform.Translate(Vector2.down * Time.deltaTime * speed);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("boat")) {
			currentState = State.LANDED;
			animator.SetBool("landed", true);
		}
	}
}
