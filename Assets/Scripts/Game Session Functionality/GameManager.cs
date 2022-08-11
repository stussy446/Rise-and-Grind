using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    Vector2 currentPlayerSpawnPoint;
    int numberOfSpawns = 0;
    //GameObject startingCheckpoint;

    //public Vector2 SpawnPoint
    //{
    //    get => currentPlayerSpawnPoint;
    //    set => currentPlayerSpawnPoint = value;
    //}

    //public int NumberOfSpawns
    //{
    //    get => numberOfSpawns;
    //    set => numberOfSpawns = value;
    //}

    private void Awake()
    {
        // singleton pattern to make sure only one GameManagerManager persists per scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }


    //public Vector2 SetPlayerSpawnPoint()
    //{
    //    return currentPlayerSpawnPoint;
    //}


    /// <summary>
    /// loads next level in the game, if there is no next level, resets to first level 
    /// </summary>
    public void LoadNextLevel()
    {

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        

        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex);
        }

        numberOfSpawns = 0;

    }


}
