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
