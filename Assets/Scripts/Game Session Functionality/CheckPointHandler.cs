using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{
    PlayerLifeSystem playerLifeSystem;
    Vector2 spawnPoint;
    ScenePersist currentScene;


    void Start()
    {
        currentScene = FindObjectOfType<ScenePersist>();
    }


    /// <summary>
    /// when the checkpoint is reached, it sets the spawnpoint in the game manager
    /// to the position of this checkpoint and then destorys the checkpoint
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentScene.CurrentCheckpointPos = this.gameObject.GetComponent<Transform>().position;
        Debug.Log("new position is: " + currentScene.CurrentCheckpointPos);
        Debug.Log("scene persist checkpoint set to: " + currentScene.CurrentCheckpointPos);
        DisableCheckpoint();
    }


    public void DisableCheckpoint()
    {
        Destroy(gameObject);
    }

}
