using UnityEngine;
using System.Collections;

public class LiikkumisBehaviour : MonoBehaviour 
{
		
	public bool nappiPohjassa;
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	void OnClick()
	{
		GameObject.Find("StaticPlayer").SendMessage("Liiku");
	}
}
