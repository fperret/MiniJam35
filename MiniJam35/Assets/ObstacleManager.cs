using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

	public GameObject wood;

	IEnumerator spawnWood()
	{
		while (true)
		{
			GameObject tmpWood = Instantiate(wood, new Vector3(7, Random.Range(0, 10), 0), transform.rotation);
			yield return new WaitForSeconds(2);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(spawnWood());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
