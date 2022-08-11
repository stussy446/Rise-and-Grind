using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    public static ScenePersist instance;
    Vector3 currentCheckpointPos = new Vector3(0, 0, 0);
    bool firstLife = true;

    private void Awake()
    {
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

    public bool FirstLife
    {
        get => firstLife;
        set => firstLife = value;
    }

    public Vector2 CurrentCheckpointPos
    {
        get => currentCheckpointPos;
        set => currentCheckpointPos = value;
    }


    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
