using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{
    PlayerLifeSystem playerLifeSystem;
    Vector2 spawnPoint;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerLifeSystem = FindObjectOfType<PlayerLifeSystem>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public Vector2 SpawnPoint
    {
        get => spawnPoint;
        set => spawnPoint = value;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawnPoint = GetComponent<Transform>().position;

        if (playerLifeSystem.CurrentCheckpointPos != spawnPoint)
        {
            playerLifeSystem.CurrentCheckpointPos = spawnPoint;

        }
    }

    public void ResetPlayerSpawnPoint()
    {
        playerLifeSystem.CurrentCheckpointPos = new Vector2(0,0);
    }
}
