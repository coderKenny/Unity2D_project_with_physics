using UnityEngine;
using System.Collections;

public class SliderExample : MonoBehaviour
{
    float repairOmeter = 0.0f;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 20, 100, 20), "Repair Meter Over Time");
        repairOmeter = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), repairOmeter, 0.0F, 10.0F);
        repairOmeter = (int)repairOmeter; //only for Int
    }
}