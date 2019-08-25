using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleManager : MonoBehaviour {

	public GameObject rock;
	public GameObject valkyrie;
	public GameObject shadow;
	private float obstacleSpeed = 5;

	private List<GameObject> liveHorizontalObstacles;
	private List<GameObject> liveVerticalObstacles;
	private List<GameObject> liveVerticalShadows;

	private Transform boat;


	IEnumerator spawnRock()
	{
		while (true)
		{
			// Todo dynamic range related to the ship

			GameObject tmpRock;
			Vector3 rockPos;
			while (true) {
				rockPos = new Vector3(boat.position.x + 36, Random.Range(0, 10), 0);
				if (!Physics.CheckSphere(rockPos, 3))
					break;
			}
			tmpRock = Instantiate(rock, rockPos, transform.rotation);
			liveHorizontalObstacles.Add(tmpRock);
			yield return new WaitForSeconds(2);
		}
	}


	IEnumerator spawnValkyrie()
	{
		while (true)
		{
			// TODO dymanic range related to the ship
			float boatLeftmostPosX = 0.6f;
			float boatRightmostPosX = 5.4f;
			float xPosition = Random.Range(boat.position.x + boatLeftmostPosX, boat.position.x + boatRightmostPosX);
			GameObject tmpValkyrie = Instantiate(valkyrie, new Vector3(xPosition, 16), transform.rotation);

			GameObject tmpShadow = Instantiate(shadow, new Vector3(xPosition, boat.position.y + 0.78f), transform.rotation);
			tmpShadow.GetComponent<Shadow>().ownerInstanceID = tmpValkyrie.GetInstanceID();
			tmpShadow.transform.parent = boat;

			liveVerticalObstacles.Add(tmpValkyrie);
			yield return new WaitForSeconds(6);
		}
	}

	// Use this for initialization
	void Start () {
		boat = GameObject.Find("Boat").transform;

		liveHorizontalObstacles = new List<GameObject>();
		liveVerticalObstacles = new List<GameObject>();
		StartCoroutine(spawnRock());
		StartCoroutine(spawnValkyrie());
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject obstacle in liveHorizontalObstacles) {
			obstacle.transform.Translate(Vector2.left * Time.deltaTime * obstacleSpeed);
		}

		if (liveHorizontalObstacles.Count > 100) {
			// TBD : Check if objects are outside of the camera
			liveHorizontalObstacles.RemoveRange(0, 50);
		}
		if (liveVerticalObstacles.Count > 100) {
			// TBD : Check if objects are outside of the camera
			liveVerticalObstacles.RemoveRange(0, 50);
		}
	}
}
