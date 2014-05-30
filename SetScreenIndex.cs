using UnityEngine;
using System.Collections;

public class SetScreenIndex : MonoBehaviour 
{
	public Singleton sinkku;

	// Use this for initialization
	void Start () 
	{
		sinkku=Singleton.Instance;
		
		sinkku.setIndex(0);
	}
}
