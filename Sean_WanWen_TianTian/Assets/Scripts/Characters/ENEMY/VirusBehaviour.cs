using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VirusBehaviour : MonoBehaviour {

	private GameObject Target;
	private Transform targetPos;
	public float speed;

	// Use this for initialization
	void Start () {
		Target = GameObject.Find("Player");
		targetPos = Target.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.GetComponent<Rigidbody2D>().isKinematic == false)
			{
				this.GetComponent<Rigidbody2D>().isKinematic = true;
			}

		if (Target) 
		{
			transform.position = Vector3.MoveTowards (transform.position, targetPos.position, speed * Time.deltaTime);
		}

		if (this.GetComponent<BoxCollider2D>().isTrigger == false)
		{
			this.GetComponent<BoxCollider2D>().isTrigger = true;
		}
		if (this.transform.position == targetPos.position) {
			Destroy(gameObject);
		}
	}
}
