using UnityEngine;
using System.Collections;

public class TextMeshExample : MonoBehaviour
{
    tk2dTextMesh textMesh;
	public int score;
	
	public Singleton sinkku;
	
    // Use this for initialization
    void Start()
    {
		sinkku=Singleton.Instance;
        textMesh = GetComponent<tk2dTextMesh>(); 
		score=0;
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
	
	
	void addPoints()
	{
		 score++;
		
		textMesh.text = "^3  " + score.ToString();

            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
            textMesh.Commit();
			sinkku.addPoints(score);
	}
}