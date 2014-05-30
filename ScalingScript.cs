using UnityEngine;
using System.Collections;

public class ScalingScript : MonoBehaviour 
{
    private GameObject me;
    private float skaala;
    private float kerroin;

    public Singleton sinkku;

//    private Camera playerCamera;

    //private float orkkisSkaala;

	// Use this for initialization
	void Start () 
    {
        sinkku = Singleton.Instance;
        

        me = GameObject.Find("RayCastPlane");

        kerroin = 0.00347f;

        // 1.1/1080 = x/screenHeight*x
        // x=1.1/1080*
      //  orkkisSkaala = me.transform.localScale.z;

        kerroin = (1.1f / 1080f) * Screen.height;

        Debug.Log("Alun skaala : +" + me.transform.localScale);

        //skaala=playerCamera.sc.height*2;

        // OK S4:ssa -> 1080p 
        //kerroin = orkkisSkaala / Screen.height;
        // Pit‰‰ olla sama

        //kerroin / Screen.height == orkkisSkaala / Screen.height;

        //kerroin *= 1000; 
        
        // = n. 3.47f;

        me.transform.localScale=new Vector3(me.transform.localScale.x,me.transform.localScale.y,kerroin); // More
        me.transform.localScale = new Vector3(me.transform.localScale.x, me.transform.localScale.y,kerroin*=10);

        Singleton.userFloatList.Add(kerroin);
        //me.transform.localScale.z = kerroin;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Debug.Log("OrkkisSkaala on : +" + orkkisSkaala);
        //Debug.Log("LaskettuKerroin on : +" + kerroin);
        //Debug.Log("Uusskaala : +" + me.transform.localScale);
	
	}
}
