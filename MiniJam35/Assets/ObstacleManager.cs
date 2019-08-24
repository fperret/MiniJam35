using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleManager : MonoBehaviour {

	public GameObject wood;
	public float obstacleSpeed = 1.5f;

	private List<GameObject> liveObstacles;

	IEnumerator spawnWood()
	{
		while (true)
		{
			GameObject tmpWood = Instantiate(wood, new Vector3(7, Random.Range(0, 10), 0), transform.rotation);
			liveObstacles.Add(tmpWood);
			yield return new WaitForSeconds(2);
		}
	}

	// Use this for initialization
	void Start () {
		liveObstacles = new List<GameObject>();
		StartCoroutine(spawnWood());
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject obstacle in liveObstacles) {
			obstacle.transform.Translate(Vector2.left * Time.deltaTime * obstacleSpeed);
		}
	}
}
