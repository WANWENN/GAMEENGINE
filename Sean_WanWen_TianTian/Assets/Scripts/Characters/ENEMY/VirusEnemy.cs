using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VirusEnemy : MonoBehaviour
{
	//Enemy FSM
	public enum E_State
	{
		STATE_IDLE,
		STATE_MOVE,
		STATE_ATTACK,
		STATE_FALL,
		STATE_TOTAL
	} public E_State theState = E_State.STATE_MOVE;
	
	public Collider WayPointsBoundary;
	short CurIndex = 0;
	public List<Vector3> WayPoints_List = new List<Vector3>();
	bool isLeft = false;
	void Move()
	{
		//Random Way Points System
		float BufferZone = 5.0f, MovementSpeed = 2.0f;
		if ((this.transform.position - WayPoints_List[CurIndex]).sqrMagnitude > BufferZone)
			this.transform.position = Vector2.MoveTowards(this.transform.position, WayPoints_List[CurIndex], MovementSpeed * Time.deltaTime);
		else
		{
			WayPoints_List.Add(RandomizeWayPoint());
			++CurIndex;
		}
		
		//Set Face Dir
		isLeft = (this.transform.position.y - WayPoints_List[CurIndex].y < 0);
	}
	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player") 
		{
			Debug.Log ("DAMAGE");
			//transform.Getchild(healthbar).GetComponent<UnitStats>().HP--;
			//col.GetComponent<HealthBar>().DecreaseHp();
			this.GetComponentInChildren<VirusHp>().DecreaseHp();
		}
	}
	Vector3 RandomizeWayPoint()
	{
		return new Vector3(Random.Range(WayPointsBoundary.transform.position.x - WayPointsBoundary.bounds.size.x * 0.5f,
		                                WayPointsBoundary.transform.position.x + WayPointsBoundary.bounds.size.x * 0.5f),
		                   Random.Range(WayPointsBoundary.transform.position.y - WayPointsBoundary.bounds.size.y * 0.5f,
		             	   WayPointsBoundary.transform.position.y + WayPointsBoundary.bounds.size.y * 0.5f),
		                   0.0f);
	}
	
	void ExecuteState()
	{
		switch (this.theState)
		{
		case E_State.STATE_IDLE:
			break;
		case E_State.STATE_FALL:
			break;
		case E_State.STATE_MOVE:
			Move();

			//Flip
			if (!isLeft)
			{
				if (this.GetComponent<Animator>().GetInteger("Type") != 0)
					this.GetComponent<Animator>().SetInteger("Type", 0);
			}
			if (isLeft)
			{
				if (this.GetComponent<Animator>().GetInteger("Type") != 1)
					this.GetComponent<Animator>().SetInteger("Type", 1);
			}
			break;
		case E_State.STATE_ATTACK:
			break;
		default:
			break;
		}
	}
	
	//Use this for initialization
	void Start()
	{
		//Create 1st Random Way Point
		WayPoints_List.Add(RandomizeWayPoint());
	}
	
	//Update is called once per frame
	void Update()
	{
		//Execute FSM
		ExecuteState();
	}
}
