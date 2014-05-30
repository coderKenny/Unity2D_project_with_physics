using UnityEngine;
using System.Collections;

public class AlkuSkripti : MonoBehaviour 
{
    // Main menu's script
    
    public Singleton sinkku;


    private GUIStyle style;

    private bool allowDrag = true;



    private Rect startRect;
    private Rect targetRect;

    



	// Use this for initialization
	void Start () 
    {
        startRect = new Rect((Screen.width / 2)*0.1f, Screen.height / 2*0.3f, Screen.height / 2+100, Screen.height / 2+200); 

        sinkku = Singleton.Instance;
        sinkku.setIndex(0);

        // Ensure the audio is on -> can be muted after the return from playScreen
        if (!sinkku.giveMuteState())
        {
            // Change pause menu sprite to indicate the mute. It get's reseted when scene is loaded
            //GameObject.Find("MuteButton").SendMessage("SwapToMutedImage");
            //maini.GetComponent("Audio Listener") as AudioListener.pause = false; 
            AudioListener.pause = false;

            if (sinkku.isPaused())
            {
                GameObject.FindGameObjectWithTag("Player").SendMessage("resumeMusic");
                sinkku.resume();
            }

            sinkku.toggleMute(); // Kuittaa se vittuun !
        }
	}

    /*

    public void OnGUI()
    {
        // Make GUI box
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = Color.blue;
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 30;
        }

        // Register the window (window ID must be unique)
        startRect = GUI.Window(1, startRect, DoMyWindow, "");
    }



    void DoMyWindow(int windowID)
    {
        // Debug box content ->
        GUI.Label(new Rect(0, 0, startRect.width, startRect.height), "isMuted arvo : " + sinkku.giveMuteState() + "\nisPaused arvo : " + sinkku.isPaused() + "\nGravitaatio : " + Physics.gravity.y + "\nAlkuRectangeli : \n" + startRect + "\nAudioListener bool : " + AudioListener.pause, style);
        if (allowDrag)
        {
            //GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
            // Drag from upper "bar"
            //GUI.DragWindow(new Rect(0, 0, 10000, 20));


            GUI.Button(new Rect(10, 8, 120, 20), "Debug screen !!!");
            // Insert a huge dragging area at the end.
            // This gets clipped to the window (like all other controls) so you can never
            //  drag the window from outside it.
            GUI.DragWindow();
        }
    }
     */
}
