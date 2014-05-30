using UnityEngine;
using System.Collections;

public class NappulaSkripti : MonoBehaviour 
{	
    private Ray touchRay;

    private RaycastHit touchHit;

    private GUIText messages;

    //private GameObject oggetto;
 

    private Camera inputCamera;

	/*void OnMouseDown() 
	{
		if(collider.transform.tag=="Back")
		{
        	Application.LoadLevel("Options");
		}
		
		if(collider.transform.tag=="Forward")
		{
        	Application.LoadLevel("Info");
		}
    }
	*/
	
	
	
	void Awake()
	{	
		if(!inputCamera)
		{
			inputCamera = Camera.main;

            //oggetto = GameObject.Find("Forward");

            //messages = (GUIText) oggetto.GetComponent("GUIText");

        }

    }
	
	
	
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame	
	void Update () 
	{
		/*int fingerCount = 0;
        
		foreach (Touch touch in Input.touches) 
		{
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                fingerCount++;
            
        }
        
		if (fingerCount > 0)
            Debug.Log("User has " + fingerCount + " finger(s) touching the screen");
        
    }
    */
		
		if ((Input.touchCount == 1) &&(Input.GetTouch(0).phase == TouchPhase.Began) )
    	{
     	//Input.GetTouch(0)
		Debug.Log ("TouchPositio "+ Input.GetTouch(0));
    	}
	}
}
		
		
		


