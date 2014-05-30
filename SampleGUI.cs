// #######################################
// ---------------------------------------
// ---------------------------------------
// Kenneth Ekbom
// ---------------------------------------
// Esimerkki GUI
// ---------------------------------------
// Contact:
// 		kenne@dnainternet.net
// ---------------------------------------
// #######################################


using UnityEngine;
using System.Collections;
//using System;


[AddComponentMenu("Sample GUIs/Unity styled GUI")]
public class SampleGUI : MonoBehaviour 
{
	
	[System.Serializable]
	public class SceneData 
    {
        public string name;
        public string path;
	}
	
	public SceneData[] scenes;
	public GUISkin guiSkin;  // Default if NULL
	
	public Vector2 scrollVector = Vector2.zero;
  

    public virtual void Start()
    {
        
    }

    public virtual void OnGUI() 
    {

        GUI.skin = guiSkin;

        GUI.color = Color.white;

        //uiSkin.button.normal.textColor = Color.green;


		// Screen.height - Screen.height / 5
		scrollVector=GUI.BeginScrollView(new Rect(Screen.width/2 - 100, Screen.height/10, 230, Screen.height * 0.8f), scrollVector, new Rect(0,0,200,scenes.Length * 50));
		
        //guiSkin.scrollView.

//		GUILayout.BeginArea(new Rect(0, 0, 300, scenes.Length * 50));
		
		foreach(SceneData s in scenes)
		if(GUILayout.Button(s.name+"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", GUILayout.Height(50), GUILayout.Width(200)))
		{
			Debug.Log("Loading scene:xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx " + s.name);
			Application.LoadLevel(s.path);
		}
		
//		GUILayout.EndArea();
		
		GUI.EndScrollView();
	}
}
