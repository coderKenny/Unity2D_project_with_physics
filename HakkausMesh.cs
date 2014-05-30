using UnityEngine;
using System.Collections;

public class HakkausMesh : MonoBehaviour 
{

    tk2dTextMesh textMesh;
	public int score;
	
	public Singleton sinkku;
	
	private GameObject pisteetPelinJalkeen;
	
    // Use this for initialization
    void Start()
    {
		// Grab a handle to text mesh
		pisteetPelinJalkeen=GameObject.Find("FinalPisteet");
        //pisteetPelinJalkeen = GameObject.Find("Pisteet2");
        if(pisteetPelinJalkeen!=null)
		    pisteetPelinJalkeen.transform.renderer.enabled=false;
		
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
		//score++;
		score += 1000;
		
		if(score >=10000)
		{
		 	int pala1=score/1000;
			int pala2=score-pala1*1000;
			textMesh.text = "^3  " +pala1.ToString()+" "+pala2.ToString()+"00"; // Main counter
			pisteetPelinJalkeen.GetComponent<tk2dTextMesh>().text = "^3  " +pala1.ToString()+" "+pala2.ToString()+"00"+" points !!"; // Secondary counter
		}
		
		else
		{
			textMesh.text = "^3  " + score.ToString();
			pisteetPelinJalkeen.GetComponent<tk2dTextMesh>().text = "^3  " + score.ToString()+" points !!";
		}	
		
		textMesh.Commit();
		sinkku.addPoints(score);
		
		// Update other counter too
		pisteetPelinJalkeen.GetComponent<tk2dTextMesh>().Commit();
			
	}
	
	void ShowHighScore()
	{
		pisteetPelinJalkeen.transform.renderer.enabled=true;
	}
}
