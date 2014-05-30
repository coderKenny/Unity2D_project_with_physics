using UnityEngine;
using System.Collections;

public class ResumeBehaviour : MonoBehaviour 
{
	void OnClick()
	{
		GameObject.Find("Pause").SendMessage("Pause");
	}
}
