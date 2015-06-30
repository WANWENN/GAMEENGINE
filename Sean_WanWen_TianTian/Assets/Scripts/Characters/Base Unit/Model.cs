﻿using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour 
{
    //Every Model has it's own Walking Collision Region
    public CollisionRegion WalkCollisionRegion;
    public bool isAnimated = true;

    //Returns own Animator
    public Animator GetAnimation()
    {
        if (isAnimated)
            return this.GetComponent<Animator>();
        return null;
    }

    //Set Animation
    public void SetAnimation(short AnimationIndex)
    {
        if (isAnimated)
            this.GetComponent<Animator>().SetInteger("Direction", AnimationIndex);
    }

	//Use this for initialization
	void Start () 
    {
        //Default to first Animation
        SetAnimation(0);
	}
	
	//Update is called once per frame
	void Update () 
    {
	
	}
}
