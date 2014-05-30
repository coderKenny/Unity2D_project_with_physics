using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		GameObject.FindGameObjectWithTag("GameOver").transform.Translate(20,0,0);
		//NGUITools.SetActive(GameObject.FindGameObjectWithTag("GameOver"),false);
	
	}
	
	void restoreMe()
	{
		StartCoroutine(WaitAndPrint(1.5f));	
		//NGUITools.SetActive(GameObject.FindGameObjectWithTag("GameOver"),true);	
	}
	
	public IEnumerator WaitAndPrint(float waitTime)
    {
		yield return new WaitForSeconds(waitTime);
		GameObject.FindGameObjectWithTag("GameOver").transform.Translate(-20,0,0);			
	}
	
	void OnClick()
	{
		Application.LoadLevel("Simple");
	}
}