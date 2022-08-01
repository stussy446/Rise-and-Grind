using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{
    PlayerLifeSystem playerLifeSystem;
    Vector2 spawnPoint;
    GameManager gameManager;


    void Start()
    {
        playerLifeSystem = FindObjectOfType<PlayerLifeSystem>();
        gameManager = FindObjectOfType<GameManager>();
    }


    /// <summary>
    /// when the checkpoint is reached, it sets the spawnpoint in the game manager
    /// to the position of this checkpoint and then destorys the checkpoint
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.SpawnPoint = GetComponent<Transform>().position;
        DisableCheckpoint();
    }


    public void DisableCheckpoint()
    {
        Destroy(gameObject);
    }

}
