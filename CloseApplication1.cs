using UnityEngine;
using System.Collections;

public class CloseApplication1 : MonoBehaviour 
{
	
	KeyCode key = KeyCode.Escape;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(key))
        {
            Debug.Log("Trying to bail !! :)");
            Application.Quit();
        }
	}
}
