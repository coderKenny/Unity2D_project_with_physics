using UnityEngine;
using System.Collections;

public class Fader2 : MonoBehaviour 
{
	
	public GUITexture FeidausPalikka;
	
	void Start()
	{
	}
	
	void GameOverSucker () 
	{
		Vector3 pos = new Vector3(0.5f, 0.5f, -5.0f);
		Instantiate(FeidausPalikka, pos, transform.rotation);
		GameObject.Find("Hakkaaja").SendMessage("hideMe");
		GameObject.FindGameObjectWithTag("GameOver").SendMessage("restoreMe");
		GameObject.FindGameObjectWithTag("Tausta1").SendMessage("changeGameOverScreen");
		GameObject.Find("Pisteet").SendMessage("ShowHighScore");
	}


    void killMe()
    {
        GameObject.Destroy(this.gameObject);
    }
}