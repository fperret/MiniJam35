using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

	public int ownerInstanceID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("playerObstacle")) {
				if (other.gameObject.GetInstanceID() == ownerInstanceID) {
					GameObject.Destroy(gameObject);
		//			other.gameObject.SetActive(false);
				}
		}

	}
}
