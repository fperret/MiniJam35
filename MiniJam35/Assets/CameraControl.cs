using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	private Vector3 startingPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void screenShake()
	{
		startingPos = transform.position;
		InvokeRepeating("startShaking", 0, 0.01f);
		Invoke("stopShaking", 0.3f);
	}

	private void startShaking()
	{
		Debug.Log("shake");
		Vector3 newPos = transform.position;
		if (Random.value > 0.5f) {
			newPos.y += Random.Range(-1.0f, 1.0f) * 0.04f;
		}
		else {
			newPos.x += Random.Range(-1.0f, 1.0f) * 0.04f;
		}
		transform.position = newPos;
	}

	private void stopShaking()
	{
		CancelInvoke("startShaking");
		transform.position = startingPos;
	}
}
