using UnityEngine;
using System.Collections;

public class SplashEffect : MonoBehaviour 
{
	private Component emitteri;
	
	
	void Start()	
	{
		emitteri = GetComponent<ParticleEmitter>();
	}
	
	void stopEffect()
	{
		emitteri.renderer.enabled=false;
	}
	
	
	void startEffect()
	{
		//GetComponent<ParticleEmitter>().enabled=true;
		emitteri.renderer.enabled=true;
	}
	

}
