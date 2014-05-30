using UnityEngine;
using System.Collections;

[AddComponentMenu("HelpTools/RayCast kuutio")]
public class RayCube : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        RaycastHit hit;
        int layerMask = 1 << 20;
        Ray ray = new Ray();

        ray.origin = gameObject.transform.position;
        ray.direction = gameObject.transform.forward;


        Physics.Raycast(ray, out hit, 50f, layerMask);

        Debug.DrawRay(ray.origin, ray.direction * 15f, Color.white);
        Debug.DrawRay(ray.origin, ray.direction * -15f, Color.black);
        Debug.DrawRay(ray.origin, gameObject.transform.up * -15f, Color.blue);
        Debug.DrawRay(ray.origin, gameObject.transform.up * 15f, Color.red );

        Debug.DrawRay(ray.origin, gameObject.transform.right * 15f, Color.green);
        Debug.DrawRay(ray.origin, gameObject.transform.right * -15f, Color.magenta);
	}
}
