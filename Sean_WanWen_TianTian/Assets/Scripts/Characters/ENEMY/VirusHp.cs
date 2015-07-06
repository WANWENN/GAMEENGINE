using UnityEngine;
using System.Collections;

public class VirusHp : MonoBehaviour 
{
	public UnitStats theUnit;
	float InitialScale;
	float HP = 10.0f, MAX_HP = 10.0f;
	float DmgInterval = 0;
	
	// Use this for initialization
	void Start () 
	{
		//Store Initial Scale
		InitialScale = this.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(DmgInterval > 0)
			DmgInterval -= Time.deltaTime;

		//Set Cur Scale
		float CurScaleX = this.transform.localScale.x;
		
		//Set New Scale
		CurScaleX = InitialScale * (theUnit.HP / theUnit.MAX_HP);
		
		//Modify Scale
		this.transform.localScale = new Vector3(CurScaleX, this.transform.localScale.y, this.transform.localScale.z);
	}

	public void DecreaseHp()
	{
		if (DmgInterval <= 0) 
		{
			DmgInterval = 0.5F;
			theUnit.HP -= 3;
			if (theUnit.HP < 0)
				Destroy(theUnit.transform.parent.gameObject);
		}
	}
}
