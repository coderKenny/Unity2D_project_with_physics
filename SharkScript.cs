using UnityEngine;
using System.Collections;

public class SharkScript : MonoBehaviour 
{

    public AudioClip molskis;
	public AudioClip klippi;
	//Camera kamera2;
	public Camera Camera2;
	
	private GameObject[] gos;
	
	
	// Use this for initialization
	void Start () 
	{
		Camera2.camera.enabled=false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	
	void OnTriggerEnter(Collider col) 
	{
			//Debug.Log("Collider on "+col.ToString());
			gos=GameObject.FindGameObjectsWithTag("Kolikot");
			Camera.main.enabled=false;
			Camera2.enabled=true;
			
			GameObject.Find("StaticPlayer").SendMessage("EndAudio");
			

            // Huom. audio listerer on ykköskamerassa, tässä 
			AudioSource.PlayClipAtPoint(klippi,col.transform.position);
			
			GameObject.Find("HaiKuolema").SendMessage ("PlayClip");
			
			foreach(GameObject go in gos)	// Tuhoa kaikki myntit
			{
				go.SendMessage("TuhoaNe");
			}
			//GameObject.Find("StaticPlayer").SendMessage("Die");
	}
	
	void OnWaterDeath()
	{
        AudioSource.PlayClipAtPoint(molskis, Camera.main.transform.position);
        //AudioSource.PlayClipAtPoint(molskis, Camera2.transform.position);
		gos=GameObject.FindGameObjectsWithTag("Kolikot");
		
		foreach(GameObject go in gos)	// Tuhoa kaikki myntit
		{
			go.SendMessage("TuhoaNe");
		}
		
		//Camera.main.enabled=false;
		Camera2.enabled=true;
			
		GameObject.Find("StaticPlayer").SendMessage("EndAudio");
			
		//AudioSource.PlayClipAtPoint(klippi,col.transform.position);
			
		GameObject.Find("HaiKuolema").SendMessage("tuhoaAnimaatio");
		
		GameObject.Find("VesiKuolema").SendMessage ("PlayClip2");
			
	
			//GameObject.Find("StaticPlayer").SendMessage("Die");
	}
	
}
