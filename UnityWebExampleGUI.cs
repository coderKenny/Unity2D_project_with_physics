using UnityEngine;
using System.Collections;


[AddComponentMenu("Sample GUIs/Unity styled GUI - Web Example")]
public class UnityWebExampleGUI : SampleGUI 
{

    public override void Start()
    {
        // Inherited -->
        base.Start();
       // guiSkin.button.
            //.Button(new Rect(0, 0, 100, 20), "Top-left");
    }

    


    public override void OnGUI()
    {
        // Scroll vector == ScrollPosition
        base.scrollVector = GUI.BeginScrollView(new Rect(10, 300, 100,50), base.scrollVector, new Rect(0, 0, 220, 200));
        GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
        GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
        GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
        GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");
        GUI.EndScrollView();
    }
}