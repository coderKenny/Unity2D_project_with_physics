using UnityEngine;
using System.Collections;

public class MaaliSkripti : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "StaticPlayer") 
		{
			//GameObject.Find("Pisteet").SendMessage("addPoints");
			
			//AudioSource.PlayClipAtPoint(klippi,col.transform.position);
			Application.LoadLevel("Onnittelut");
			//Destroy (gameObject);
		}
	}
	
}
