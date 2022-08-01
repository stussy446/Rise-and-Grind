using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public UnityEvent OnNextLevelLoad;
    public bool isLoadingLevel = false;

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

    void Start()
    {
        if (OnNextLevelLoad == null)
        {
            OnNextLevelLoad = new UnityEvent();
        }

    }



    public void LoadNextLevel()
    {
        OnNextLevelLoad?.Invoke();
        isLoadingLevel = true;
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
    }

   
}
