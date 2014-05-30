using UnityEngine;
using System.Collections;

public class PauseKaytos : MonoBehaviour 
{
	public tk2dButton nappi;

    public UISprite eteen;
    public UISprite taakse;

    public GameObject[] napit;
	
	public Singleton sinkku;
	public GUITexture FeidausPalikka;


	void Start () 
	{
		sinkku=Singleton.Instance;
		sinkku.resume();	//  Stupid way to toggle pause but unsure where to initialize Singleton variable :/
		
		napit=GameObject.FindGameObjectsWithTag("LiikkumisNapit");
        eteen = napit[0].GetComponent<UISprite>();
        taakse = napit[1].GetComponent<UISprite>();
      
	}
		
	public void hideButtons()
	{	
		eteen.enabled=false;
		taakse.enabled=false;
	}
	
	public void showButtons()
	{
		eteen.enabled=true;
		taakse.enabled=true;
	}
	
	
	
	public IEnumerator Pause()
	{
		if(!sinkku.isPaused())
		{
			this.hideButtons();
			sinkku.pause(); // Indicate pause state to Singleton
			//Debug.Log("Game paused !!!!");
			Vector3 pos = new Vector3(0.5f, 0.5f, -5.0f);
            Instantiate(FeidausPalikka, pos, transform.rotation);  // killMe is called to destroy !

            yield return new WaitForSeconds(0.5f);	

			Time.timeScale=0;	// Full speed is 1, now set it to full STOP

            GameObject.FindGameObjectWithTag("MuteCamera").SendMessage("FireUpNGUIelementit");
		}
		
		else
		{
            // NEVER(?) keep this value other than 1 here !!! Because you probably rely on yields, timers etc. 
            // THEY WON'T RUN if time is stopped  >>>
            Time.timeScale = 1; 
            /////////////////////////////////////////////////////////////////////////////////////////////////
                     
			GameObject.FindGameObjectWithTag("Faderi").SendMessage("killMe");
			
			GameObject.FindGameObjectWithTag("MuteCamera").SendMessage("FireDownNGUIelementit");
         
			sinkku.resume();
			this.showButtons();
		}
	}
}
