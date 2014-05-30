using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	private GameObject pelaaja;
	
	public AudioListener kuuntelija;
	
	// Use this for initialization
	void Start () 
	{
		pelaaja=GameObject.Find("StaticPlayer");
		kuuntelija = GetComponent<AudioListener>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float pelaajanX=pelaaja.transform.position.x+0.5f;
		float pelaajanY=pelaaja.transform.position.y;
		transform.position = new Vector3(pelaajanX,pelaajanY,transform.position.z);
		// kamera.transform.position.Set(pelaaja.transform.position.x,kamera.transform.position.y,kamera.transform.position.z);
	}
	
	// Fired elsewhere
	void Scoring()
	{
		//kamera.transform.rigidbody.AddForce(new Vector3(1, 0, 0) * 10);
	}
	
	void disableAudioListener()
	{
        AudioListener.pause = true;
		//kuuntelija.enabled=false;	
	}
	
	
	void enableAudioListener()
	{
        AudioListener.pause = false;
		//kuuntelija.enabled=true;	
	}
	
	
}
