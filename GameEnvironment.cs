using System;
using UnityEngine;

public class GameEnvironment
{
    private static GameEnvironment instance;
    private SMSceneManager sceneManager;

    // This Property allows you to access the GameEnvironment class from everywhere 
    // in your project.
    public static GameEnvironment Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnvironment();
            }
            return instance;
        }
    }

    // With this property you can access the configured instance of SMSceneManager
    public SMSceneManager SceneManager
    {
        get
        {
            return sceneManager;
        }
    }

    // This constructor does the setup.
    private GameEnvironment()
    {
        // Create a new instance of SMSceneManager and use the SMSceneConfigurationLoader class
        // to lookup the active scene configuration from a folder named "Config"
        sceneManager = new SMSceneManager(SMSceneConfigurationLoader.LoadActiveConfiguration("Config"));
        // Attach the default level progress tracker to Scene Manager.
        sceneManager.LevelProgress = new SMLevelProgress(sceneManager.ConfigurationName);
    }
}