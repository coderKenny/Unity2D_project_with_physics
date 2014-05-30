using UnityEngine;
using System.Collections;

public class DisablePP : MonoBehaviour {
	
	public GameObject sprite;
	// Use this for initialization
	void Start () 
	{
		sprite=GameObject.FindGameObjectWithTag("TaustaNappi");
		
	
	}
	
	void Update()
	{
		sprite.GetComponent<UISprite>().transform.localScale.Set(540,558,1);
		
	}

}
