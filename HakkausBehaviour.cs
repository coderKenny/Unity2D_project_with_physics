using UnityEngine;
using System.Collections;

public class HakkausBehaviour : MonoBehaviour 
{

	public Singleton sinkku;
	
	
	void Start()
	{
		sinkku=Singleton.Instance;
		//this.GetComponent<UIButton>().enabled=true;
	}
	
	void OnClick()
	{
		GameObject.Find("Pisteet").SendMessage("addPoints");	// HandMade trigger
		
	}
	
		void OnHover()
	{
		// HandMade trigger
		
	}
}
