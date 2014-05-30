using UnityEngine;
using System.Collections;

public class LevelTransitionFunctions : MonoBehaviour 
{
    public Singleton sinkku;
    private bool started;


    void Start()
    {
        //nappi = GetComponent<tk2dButton>();

        started = true;
        sinkku = Singleton.Instance;
        //setScore();
        //setTime();
        //sinkku.setIndex(2);

    }

    void LoadSpain()
    {
        Application.LoadLevel("Spain");
    }


    void LoadLevels2()
    {
        Application.LoadLevel("Levels2");
    }


    void Reload()
    {
        Application.LoadLevel("Scene1_2");
    }

    void Options()
    {

        Application.LoadLevel("Options");
        //Application.LoadLevel("Scene1_2");
    }

    void Quit()
    {
        Application.Quit();
    }

    void MoreGames()
    {
        Application.LoadLevel("MoreGames");
    }


    void HighScores()
    {

        Application.LoadLevel("HighScore");
        //Application.LoadLevel("Scene1_2");
    }

    void Back()
    {

        sinkku = Singleton.Instance;

        // Change skenes according to Singleton index

        if (sinkku.getIndex() == 2)
            Application.LoadLevel("Onnittelut");
        else if (sinkku.getIndex() == 0)
            Application.LoadLevel("Start");
        else if (sinkku.getIndex() == 1)
            Application.LoadLevel("End");
        //Application.LoadLevel("Scene1_2");
    }

    void LoadGameOverScene()
    {

        Application.LoadLevel("End");
        //Application.LoadLevel("Scene1_2");
    }

    void LoadStartScene()
    {

        Application.LoadLevel("Start");
        //Application.LoadLevel("Scene1_2");
    }


    void Info()
    {

        Application.LoadLevel("Info");
        //Application.LoadLevel("Scene1_2");
    }

    void Tasot()
    {
        if (sinkku.getLevelState() == 0)
            Application.LoadLevel("Levelit");
        else if (sinkku.getLevelState() == 1)
            Application.LoadLevel("Levels2");
        //Application.LoadLevel("Scene1_2");
    }

    void Pause()
    {
        //Time.timeScale=0;
        //Debug.Log("Aika nyt : "+Time.timeScale);
        if(!sinkku.isPaused())
            GameObject.Find("StaticPlayer").SendMessage("pauseMusic");
        else
            GameObject.Find("StaticPlayer").SendMessage("resumeMusic");

        GameObject.Find("Pause").SendMessage("Pause");

    }


    void CollectPoints()
    {
        Debug.Log("Started state is : " + started);

        if (started)
        {
            sinkku.addPoints(0);
            started = !started;
        }
    }

}
