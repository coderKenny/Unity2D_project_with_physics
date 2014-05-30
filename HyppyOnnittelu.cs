using UnityEngine;
using System.Collections;

public class HyppyOnnittelu : MonoBehaviour 
{
    private tk2dTextMesh textMesh;
	
	public Singleton sinkku;
	
    // Use this for initialization
    void Start()
    {
		sinkku=Singleton.Instance;
        this.renderer.enabled = false;
        textMesh = GetComponent<tk2dTextMesh>(); 
    }
	

    void showMe()
    {
        this.renderer.enabled = true;
        textMesh.text = "^3Amazing airtime : " + sinkku.getHypynAika().ToString("F2");
        textMesh.Commit();
    }

    void hideMe()
    {
        this.renderer.enabled=false;
    }
	
}