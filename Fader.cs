using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour 
{
	// Muista laittaa x- ja y-position 0.5.

	// Use this for initialization
	void Start () 
	{
        // Who ?
        //Debug.Log("Olen kiinni objektissa : " + gameObject.name);
		// Tehdään tekstuurista oikean kokoinen.
		Rect currentRes = new Rect(-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height);
		guiTexture.pixelInset = currentRes;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void killMe()
    {
        GameObject.Destroy(this.gameObject);
    }
}
