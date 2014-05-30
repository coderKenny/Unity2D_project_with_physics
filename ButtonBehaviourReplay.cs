using UnityEngine;
using System.Collections;

[System.Serializable]
public class MessageArgs
{
    public bool doSomething;
    public bool answer;
  
    public MessageArgs()
    {
        doSomething = false;
        answer = false;
        // Construct !
    }
}



public class ButtonBehaviourReplay : MonoBehaviour 
{
	public Singleton sinkku;
    public GameObject pelaaja;
    MessageArgs args;

	void Start()
	{
        args = new MessageArgs();
        sinkku = Singleton.Instance;
        pelaaja = GameObject.FindGameObjectWithTag("Player"); // Gahva
		//this.GetComponent<UIButton>().enabled=true;
        Debug.Log("Napin tila startissa : " + GetComponent<UIButton>().isEnabled+" olen objekti : "+gameObject.name);
        
        // There is a problem linked to return main menu button -> it gets disabled / greys out during start up
        // This fixes it... but seems futile :s
        if(!GetComponent<UIButton>().isEnabled)
            GetComponent<UIButton>().isEnabled = true;

        Debug.Log("Napin kikkailun jalkeen : " + GetComponent<UIButton>().isEnabled + " olen objekti : " + gameObject.name);
	}
	
	
	void OnClick()  // Restart game
	{
		Time.timeScale = 1;
		
		sinkku.resume();
		
		// Scene switching

        if (this.tag.Equals("Menu"))
            Application.LoadLevel("Start");

        else
        {
            Debug.Log("Audion tila ennen : " + args.answer);
            GameObject.Find("StaticPlayer").SendMessage("TestMessage", args);
            Debug.Log("Audion tila jälkeen : " + args.answer);
            
            if (args.answer) // Use a dummy object to transfer info
            { 
               args.answer = !args.answer; // Switch back 
            }
    
            Application.LoadLevel("Scene1_2");
            

        }
	}
}
