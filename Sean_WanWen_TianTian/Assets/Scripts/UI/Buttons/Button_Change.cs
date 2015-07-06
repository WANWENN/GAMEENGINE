using UnityEngine;
using System.Collections;

public class Button_Change : Button {

	public string SceneName;

	public override void ExecuteFunction()
	{
		Application.LoadLevel(SceneName);
	}
	
	// Use this for initialization
	void Start () {
		this.ButtonType = BType.BUTTON_CHANGE;//Set Type
	}
	
	// Update is called once per frame
	void Update () {
		this.StaticUpdate(); //Update from Parent
	}
}
