using UnityEngine;
using System.Collections;

public class MovingButtonsScript : MonoBehaviour 
{

	public Singleton sinkku;
	
	public bool isPressed;
	
	private Collider kollaideri;
	
	void Start()
	{
		sinkku=Singleton.Instance;
		//this.GetComponent<UIButton>().enabled=true;
	}
	
	void OnPress(bool isDown)
	{
		isPressed=isDown;
		
		
		if(this.tag.Equals("Eteen"))
		{
			sinkku.setEtuNapinState(isPressed);
			//Debug.Log("EtuTouchi is : "+isPressed);
		}
		else
		{
			sinkku.setTakaNapinState(isPressed);
			//Debug.Log("takaTouchi is : "+isPressed);
		}
	}
}
