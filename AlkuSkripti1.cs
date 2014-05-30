using UnityEngine;
using System.Collections;

public class AlkuSkripti1 : MonoBehaviour 
{
    // Play Level script

    public Singleton sinkku;

	// Use this for initialization
	void Start () 
    {
        sinkku = Singleton.Instance;
        sinkku.setIndex(0);

        Debug.Log("MUTE STATE AFTER COMEBACK : " + sinkku.giveMuteState());

        // Ensure the audio is on -> can be muted after the return from playScreen
        if (!sinkku.giveMuteState())
        {
            GameObject.Find("MuteButton").SendMessage("SwapToMutedImage");
            AudioListener.pause = true;

            //GameObject.FindGameObjectWithTag("MainCamera").SendMessage("disableAudioListener");

         /*   if (sinkku.isPaused())
            {
                GameObject.FindGameObjectWithTag("Player").SendMessage("resumeMusic");
                sinkku.resume();
            }
          */
        }

         /*   
        }   
        
        else
        {
            GameObject.FindGameObjectWithTag("MainCamera").SendMessage("disableAudioListener");
            sinkku.toggleMute();
        }

        sinkku.toggleMute(); // Kuittaa se pois !
            */
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
