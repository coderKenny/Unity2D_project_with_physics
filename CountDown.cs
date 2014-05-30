using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour 
{
    private float vilkkuriaika=1f;
    private GameObject vilkkuri;
	private GameObject laskuri;
	
	void Start () 
	{
        vilkkuri = GameObject.Find("FeikkiNappi");
		laskuri=GameObject.Find("RunnerBar");

        vilkkuri.GetComponent<UISprite>().spriteName = "button_3";  // Valon "Alustus"... Kolmonen jo lisätty editorissa alkuarvoksi countterille

		StartCoroutine(Oota(vilkkuriaika));
        StartCoroutine(Venaa(vilkkuriaika/2));
	}
		
	public IEnumerator Oota(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);   
        laskuri.GetComponent<UILabel>().text = "2";
        yield return new WaitForSeconds(waitTime);
        laskuri.GetComponent<UILabel>().text = "1";
        yield return new WaitForSeconds(waitTime);
		laskuri.GetComponent<UILabel>().text="GO !!!";
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel("Simple");
	}

    public IEnumerator Venaa(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_1";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_3";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_1";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_3";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_1";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_3";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_1";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_3";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_1";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_3";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_1";
        yield return new WaitForSeconds(waitTime);
        vilkkuri.GetComponent<UISprite>().spriteName = "button_3";
        yield return new WaitForSeconds(waitTime);
    }
}