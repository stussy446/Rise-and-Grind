using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{
    PlayerLifeSystem playerLifeSystem;
    Vector2 spawnPoint; 

    // Start is called before the first frame update
    void Start()
    {
        playerLifeSystem = FindObjectOfType<PlayerLifeSystem>();
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
}
