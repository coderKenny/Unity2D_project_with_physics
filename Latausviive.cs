using UnityEngine;
using System.Collections;

public class Latausviive : MonoBehaviour 
{

	public float latausAika;
	// Use this for initialization
	void Start () 
	{
		latausAika=5f;
		if(gameObject.name.Equals("LoadScreen"))
			viivytaAika(latausAika);
			
		else
			StartCoroutine(Oota(5f));
	}
	
	public IEnumerator WaitAndPrint(float waitTime)
    {
		yield return new WaitForSeconds(waitTime);
        // Start a new game from the first level
        GameEnvironment.Instance.SceneManager.LoadFirstLevel();
		//Application.LoadLevel("TapOptions");
		
	}
	
	void viivytaAika(float time)
	{
		StartCoroutine(WaitAndPrint(latausAika));
	}
		
		
	public IEnumerator Oota(float waitTime)
    {
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel("Countdown");
		
	}
}