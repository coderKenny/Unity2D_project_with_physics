using UnityEngine;
using System.Collections;

public class NapinKaskytys : MonoBehaviour 
{
	void hideMe()
	{
		GetComponent<BoxCollider>().enabled=false;
		Destroy(gameObject);
	}
}
