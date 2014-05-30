using UnityEngine;
using System.Collections;

public class HaiKuolemaKoodi : MonoBehaviour 
{
	
	private tk2dAnimatedSprite anim;
	
	public GameObject haiKala;

	void Start () 
	{
		anim = GetComponent<tk2dAnimatedSprite>();
	}
	

	
	
	void PlayClip()
	{
        GameObject.Find("ButtonCamera").SendMessage("deleteDrivingButtons");    // Kill NGUI steering
        

		GameObject.Find("StaticPlayer").SendMessage("tapaPelaaja");
		GameObject.Find("VesiKuolema").transform.renderer.enabled=false;
		anim.Play("SharkAttack2");
		StartCoroutine(WaitAndPrint(5f)); 
	}
	
	void PlayClip2()
	{
        GameObject.Find("ButtonCamera").SendMessage("deleteDrivingButtons");  // Kill NGUI steering
		GameObject.Find("StaticPlayer").SendMessage("tapaPelaaja");
		//GameObject.Find("HaiKuolema").transform.renderer.enabled=false;
		
		//GameObject.Destroy(haiKala);
		
		anim.Play("Molsk");
		StartCoroutine(WaitAndPrint(5f)); 
	}
	
	public IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("WaitAndPrint " + Time.time);
		
		// Camera.main.enabled=true;
		// Camera2.enabled=false;
		
        Application.LoadLevel("End");
    }
	
	void tuhoaAnimaatio()
	{
		renderer.enabled=false;
	}
	
}
