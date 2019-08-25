using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

	public GameObject[] clouds;

	private float cloudSpawnX = 38;
	private float cloudSpawnLowerY = 14;
	private float cloudSpawnHigherY = 18;

	private List<GameObject> liveClouds;
	public GameObject cloudParent;

	IEnumerator spawnClouds()
	{
		while (true)
		{
			// Todo dynamic range related to the ship
			GameObject tmpCloud = Instantiate(clouds[(int)Random.Range(0, clouds.Length)], new Vector3(cloudSpawnX, Random.Range(cloudSpawnLowerY, cloudSpawnHigherY), 0), transform.rotation);
			liveClouds.Add(tmpCloud);
			tmpCloud.transform.parent = cloudParent.transform;
			yield return new WaitForSeconds(1);
		}
	}


	// Use this for initialization
	void Start () {
		liveClouds= new List<GameObject>();

		StartCoroutine(spawnClouds());
	}
	
	// Update is called once per frame
	void Update () {
		cloudParent.transform.Translate(Vector2.left * Time.deltaTime * 1.5f);
	}


}
