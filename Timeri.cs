using UnityEngine;
using System.Collections;


[AddComponentMenu("Utilities/While based 1s timer")]
public class Timeri : MonoBehaviour
{

    private int seconds = 0;
    private float taajuus = 1.0F;

    void Start()
    {
        // "Start" the timer implementation
        StartCoroutine(FPS());
    }



    IEnumerator FPS()
    {
        // Infinite loop executed every "frenquency" secondes.
        while (true)
        {
            // Update the FPS
            Debug.Log("Aikaa on naksunut " + seconds + " s !!");
            seconds++;
            yield return new WaitForSeconds(taajuus);
        }
    }
}
