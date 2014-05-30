using UnityEngine;
using System.Collections;

public class MoveButtonCamera : MonoBehaviour 
{

    private GameObject button1;
    private GameObject button2;
	
	private Camera kamera;

	void Start () 
    {
		kamera=GetComponent<Camera>();
		
        button1 = GameObject.Find("EteenNappi");
        button2 = GameObject.Find("TaakseNappi");
	}

    void deleteDrivingButtons()
    {
        button1.collider.enabled = false;
        button2.collider.enabled = false;

        kamera.enabled=false;
    }

}
