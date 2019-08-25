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

			// prepare the new scale because when we set the boat as parent we take the scale of the parent
			// so we need to divide our own scale
			float parentScaleX = other.transform.localScale.x;
			float parentScaleY = other.transform.localScale.y;

			Vector3 newScale = new Vector3(transform.localScale.x / parentScaleX, transform.localScale.y / parentScaleY, 1);


			transform.parent = other.transform.Find("valkyriesParent");
			transform.localScale = newScale;
		}
	}
}
