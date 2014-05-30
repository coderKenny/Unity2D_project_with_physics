using UnityEngine;
using System.Collections;
using System;

public class TimeScript : MonoBehaviour 
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
        setTime();
		sinkku.setIndex(2);
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
		
		textMesh.text = " " + sinkku.givePoints();
        textMesh.Commit();
	}

    void setTime()
    {
		float sekunneissa;
		sekunneissa=sinkku.getTotalTime();
		
		string kokonaisAika;
		    
		
		
		if(sekunneissa >= 60)
		{
			kokonaisAika=convert(sekunneissa);
			textMesh.text = " "+kokonaisAika;
        	textMesh.Commit();
		}
		
		else
		{
			kokonaisAika=sekunneissa.ToString("F2");
        	textMesh.text = " "+kokonaisAika+" s";
        	textMesh.Commit();
		}
    }
	
	string convert(float sekunneissa)
	{
		
		float minuutit=(sekunneissa/60);
		
		int tasaMinuutit=Mathf.FloorToInt(minuutit);
		
		Debug.Log(" Minuutit nyt on : "+tasaMinuutit);
		
		
		float sekunnit = sekunneissa % 60;
		
		sekunnit = Mathf.Round(sekunnit);
		
		Debug.Log(" Sekunnit nyt on : "+sekunnit);
		
		return tasaMinuutit+" min "+sekunnit+" s";
	}
	
}

