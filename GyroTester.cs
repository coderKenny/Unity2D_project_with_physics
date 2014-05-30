using UnityEngine;
using System.Collections;


public enum GyroSupported
{
    Yes,
    No
}



public class GyroTester : MonoBehaviour
{
    private bool tuettu;
    public Gyroscope m_gyroscope;
    private GUIStyle style; // The style the text will be displayed at, based en defaultSkin.label

    // Use this for initialization
    void Start()
    {
        m_gyroscope = Input.gyro;
        m_gyroscope.enabled = true;

        tuettu=SystemInfo.supportsGyroscope;

    }

    void OnGUI()
    {
        // Copy the default label skin, change the color and the alignment
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.LowerLeft;
            style.fixedWidth = 500;
            style.fixedHeight = 40;
            style.fontSize = 20;
        }

       if(tuettu) 
                GUILayout.Label("Gyroscope found !",style);
	    
       else
                GUILayout.Label("Gyroscope not found !",style);
		

        GUILayout.Label("Gyroscope attitude : " + m_gyroscope.attitude,style);
        GUILayout.Label("Gyroscope gravity : " + m_gyroscope.gravity,style);
        GUILayout.Label("Gyroscope rotationRate : " + m_gyroscope.rotationRate,style);
        GUILayout.Label("Gyroscope rotationRateUnbiased : " + m_gyroscope.rotationRateUnbiased, style);
        GUILayout.Label("Gyroscope updateInterval : " + m_gyroscope.updateInterval, style);
        GUILayout.Label("Gyroscope userAcceleration : " + m_gyroscope.userAcceleration, style);
        
    }
}