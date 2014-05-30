using UnityEngine;
using System.Collections;

public class EtuHanikka : MonoBehaviour 
{
    void OnClick()
    {
        GameEnvironment.Instance.SceneManager.LoadNextLevel();
        //Application.LoadLevel("Countdown");
    }

}
