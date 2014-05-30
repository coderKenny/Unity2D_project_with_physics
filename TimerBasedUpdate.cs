using UnityEngine;
using System.Collections;


[AddComponentMenu("Utilities/Timer pohjainen update")]
public class TimerBasedUpdate : MonoBehaviour 
{
    private float accumulator = 0F;
    public float waitTime = 5F;
    private float intervals = 0F;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        accumulator += Time.deltaTime;
        //Debug.Log("Akkumulaattori : " + accumulator);
        if (accumulator >= waitTime)
        {
            // change enabled from true to false and vice-versa.
            // do somethingkk
            //accumulator -= waitTime;
            accumulator = 0; //reset
            doTimedUpdate();
        }
	}

    void doTimedUpdate()
    {
        intervals++;
        Debug.Log("Bling, bling    "+intervals);
    }
}
