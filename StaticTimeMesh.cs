using UnityEngine;
using System.Collections;

public class StaticTimeMesh : MonoBehaviour 
{

    tk2dTextMesh textMesh;
	
	
	public float timer=10;

	public Singleton sinkku;
	
//	private bool done=false;
	
    // Use this for initialization
    void Start()
    {
		sinkku=Singleton.Instance;
        textMesh = GetComponent<tk2dTextMesh>(); 
		sinkku.setTotalTime(timer);
		setTime();
    }
	
	
    // Update is called once per frame
    void Update()
    {
		/*if(!done)
		{
			timer-=Time.deltaTime;
			sinkku.setTotalTime(timer);
		
			if(sinkku.getTotalTime()>=0)
			{
				setTime();
			}
		
			else 
			{
				confirmZero();
				GameObject.Find("PlaceRoot1").SendMessage("GameOverSucker");
				done=!done;
			}
		}
		*/
    }
    
	
	
	void setTime()
	{
		
		textMesh.text = "Time left :  " + sinkku.getTotalTime().ToString("F2")+" seconds !!!";

            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
            textMesh.Commit();
	}
	
	
	// GameOver
	void confirmZero()
	{
		textMesh.text = "Time left : 0 seconds !!!";
		GameObject.Find("FinalPisteet").SendMessage("ShowHighScore");
      	textMesh.Commit();
	}
}
