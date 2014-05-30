using UnityEngine;
using System.Collections;

[System.Serializable]
public enum SpriteStates
{
    Muted,
    unMuted
}

public class MuteBehaviour : MonoBehaviour 
{
    public SpriteStates spriteState;
	public Singleton sinkku;	
	public UISprite sprite;

	public string spriteName_On="nappi_125"; // The name of the sprite when it's on
	public string spriteName_Off="nappi_126"; // The name of the sprite when it's off	
	
	public GameObject taustakuva;
		
	void Start()
	{
		sinkku=Singleton.Instance;	
		taustakuva=GameObject.FindGameObjectWithTag("BackGround");	
		sprite=taustakuva.GetComponent<UISprite>();
	}
	
	void OnClick()
	{	
		if (sinkku.giveMuteState())
    	{
        	// Is on, turn off
        	sprite.spriteName = spriteName_Off;
            spriteState = SpriteStates.Muted;

            GameObject.FindGameObjectWithTag("MainCamera").SendMessage("disableAudioListener");
    	}
		
    	else
    	{
        	// Is off, turn on
        	sprite.spriteName = spriteName_On;
            spriteState = SpriteStates.unMuted;

            GameObject.FindGameObjectWithTag("MainCamera").SendMessage("enableAudioListener");

            if(sinkku.isPaused())
                GameObject.FindGameObjectWithTag("Player").SendMessage("pauseMusic");
    	}
        sinkku.toggleMute();
	}	

    public virtual void SwapToMutedImage()
    {
        // Change sprite to muted
        sprite.spriteName = spriteName_Off;
        spriteState = SpriteStates.Muted;
    }
}