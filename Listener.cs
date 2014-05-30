using UnityEngine;
using System.Collections;

public class Listener : MonoBehaviour
{
    //private bool audioOn;
    private bool isVisible;
    private Camera NGUIcamera;
    private GameObject button_Mute;
	
	private GameObject button1;
	private GameObject button2;
	
	private GameObject button3;
	
	public Singleton sinkku;

	// Use this for initialization
	void Start () 
    {
		button1 = GameObject.Find("MainMenuButton");
		button2 = GameObject.Find("RePlayButton");
		button3 = GameObject.Find("ResumeButton");
		
		
		
        //audioOn = true;  // Initialize audio toggler
        isVisible = false;  // Initialize third camera (NGUI) camera unvisible
        NGUIcamera = GameObject.FindGameObjectWithTag("MuteCamera").GetComponent<Camera>();
        NGUIcamera.enabled = false;

        // Hiljenna nappi samalla ->
        button_Mute = GameObject.FindGameObjectWithTag("MuteNappula");
        // button_Mute.renderer.enabled = false;    // Is Camera's child AND is not rendered if camera is OFF
        button_Mute.collider.enabled = false;
		sinkku=Singleton.Instance;
		
		
		// Kill collaiders when not visible -->
		button1.collider.enabled=false;
		button2.collider.enabled=false;
		button3.collider.enabled=false;
		
	}

    void FireUpNGUIelementit()
    {
        isVisible = ! isVisible;
        NGUIcamera.enabled =true;

        // button_Mute.renderer.enabled = true;
        button_Mute.collider.enabled = true;
		
		button1.collider.enabled=true;
		button2.collider.enabled=true;
		button3.collider.enabled=true;
    }
	
	
	void FireDownNGUIelementit()
	{
		isVisible = ! isVisible;
        NGUIcamera.enabled =false;
		button_Mute.collider.enabled = true;
		
		button1.collider.enabled=false;
		button2.collider.enabled=false;	
	}
	
	
	// Update is called once per frame
	void Update () 
    {
        // NULL_NULL_NULL
    }

    void OnActivate()
    {
        Debug.Log("Checked");
        bool check=sinkku.giveMuteState();

        if (check)
        {
            Debug.Log("Checked\n");
            Debug.Log("Muted !\n\n\n");
			sinkku.toggleMute();
        }

        else
        {
            Debug.Log("UnChecked\n");
            Debug.Log("UnMuted !\n\n\n");
			sinkku.toggleMute();
        }
    }
}
