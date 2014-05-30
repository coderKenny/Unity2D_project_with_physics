using UnityEngine;
using System.Collections;

public class TaustaScript : MonoBehaviour 
{
	
	private tk2dBaseSprite sprite;
	// Use this for initialization
	void Start () 
	{
		//GetComponent<tk2dBaseSprite>().spriteId=42;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void changeGameOverScreen()
	{


        Debug.Log("Called !! " + gameObject.name);
        GetComponent<UISprite>().spriteName = "game_over_3";
		//sprite.SetSprite(42);
	}
}
