using UnityEngine;
using System.Collections;

public class FinalScore : MonoBehaviour
{
    tk2dTextMesh textMesh;
	
	public Singleton sinkku;
	
    // Use this for initialization
    void Start()
    {
		//sinkku=Singleton.Instance;
        textMesh = GetComponent<tk2dTextMesh>();
		sinkku=Singleton.Instance;
		setScore();
    }
	
	
	/*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            score++;

            textMesh.text = "Points :   ^3  " + score.ToString();

            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
            textMesh.Commit();
        }
    }
    
    */
	
	
	void setScore()
	{
		 //score++;
		
		textMesh.text = "Points :   ^3  " + sinkku.givePoints();

            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
        textMesh.Commit();
	}
}