using UnityEngine;
using System.Collections;

public class Fader3 : MonoBehaviour 
{

	public GUITexture FeidausPalikka;
	
	void Start()
	{
		Vector3 pos = new Vector3(0.5f, 0.5f, -5.0f);
		Instantiate(FeidausPalikka, pos, transform.rotation);
	}
	
}