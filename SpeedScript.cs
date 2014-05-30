using UnityEngine;
using System.Collections;

public class SpeedScript : MonoBehaviour 
{
    tk2dTextMesh textMesh;
    //int nopeus;
	//float speed;
	//float torque;
	
	

    // Use this for initialization
    void Start()
    {
        textMesh = GetComponent<tk2dTextMesh>();
    }

	/*
    // Update is called once per frame
    void Update()
    {
		 if (Input.GetKey(KeyCode.Q))
        {
		nopeus++;

		
		textMesh.text = "Current speed : ^3 " + nopeus.ToString();

            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
            textMesh.Commit();
		}
    }
	
	*/
	
	void addSpeed(float currentSpeed)
	{
		int nopeus = (int)currentSpeed;

		
		textMesh.text = "Current speed : ^3 " + nopeus.ToString();

            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
            textMesh.Commit();
	}
	
	void addTorque(float currentTorque)
	{
		int vaanto=(int)currentTorque;	
		vaanto*=-1;
		textMesh.text = "Current forced torque : ^3 " + vaanto.ToString();
        textMesh.Commit();
	}
}