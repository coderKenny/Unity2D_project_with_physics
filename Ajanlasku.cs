using UnityEngine;
using System.Collections;

public class Ajanlasku : MonoBehaviour 
{

    tk2dTextMesh textMesh;
	
	public Singleton sinkku;
	
    // Use this for initialization
    void Start()
    {
		sinkku=Singleton.Instance;
        textMesh = GetComponent<tk2dTextMesh>(); 
    }
	
	
    // Update is called once per frame
    void Update()
    {
		setTime();
    }
    
	
	
	void setTime()
	{
		
		textMesh.text = "^3  " + sinkku.getTotalTime().ToString("F2");

            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
            textMesh.Commit();
	}
}
