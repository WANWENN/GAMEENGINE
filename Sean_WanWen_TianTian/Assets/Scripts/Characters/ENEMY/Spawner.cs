using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	private float rtime;
	
	public GameObject Virus;
	public float SpawnDelay;
	public bool eliminated = false;
	public List<GameObject> Spawned = new List<GameObject>();

	private float spawnPositionX, spawnPositionY;

	private VirusBehaviour virusBehaviour;

	// Use this for initialization
	void Start () {
	
		rtime = Time.time;

		//virusBehaviour = GetComponent<VirusBehaviour> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		spawnPositionX = Random.Range (-10, 10);
		spawnPositionY = Random.Range (-10, 10);

		if (Time.time - rtime > SpawnDelay && Spawned.Count < 10)
		{
			GameObject obj = Instantiate(Virus, 
			                     new Vector3(spawnPositionX, spawnPositionY,0),
			                     Quaternion.identity) as GameObject;

			//obj.GetComponent<VirusBehaviour>().State = 1;

			Spawned.Add(obj);
			rtime = Time.time;
		}
	}
}
