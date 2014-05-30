using UnityEngine;
using System.Collections;

public class Tweak : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        GetComponent<GUIText>().fontStyle = FontStyle.Bold;

        if (Screen.height > 1200) // iso screna
            GetComponent<GUIText>().fontSize = 30;
        else if (Screen.height > 700) // keski screna
            GetComponent<GUIText>().fontSize = 20;
        else                             // pieni screna
            GetComponent<GUIText>().fontSize = 10;

        GetComponent<GUIText>().material.color = Color.blue;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
