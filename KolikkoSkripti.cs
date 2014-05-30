using UnityEngine;
using System.Collections;

public class KolikkoSkripti : MonoBehaviour 
{
	public AudioClip klippi;
    public Singleton sinkku;

    // Use this for initialization
    void Start()
    {
        sinkku = Singleton.Instance;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col) 
	{
		if (col.gameObject.name == "StaticPlayer") 
		{
			GameObject.Find("Pisteet").SendMessage("addPoints");


            //Debug.Log("Mika osuu : " + col.gameObject.name);
			

            // Disable coin sound if pause fading is in process
            if(!sinkku.isPaused())
			    AudioSource.PlayClipAtPoint(klippi,col.transform.position);

			Destroy (gameObject);
		}
	}
	
	void TuhoaNe()
	{
		Destroy (gameObject);
	}	
}
