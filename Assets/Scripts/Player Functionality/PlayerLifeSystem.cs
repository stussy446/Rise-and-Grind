using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeSystem : MonoBehaviour, ILifeSystem
{
    [Tooltip("amount of hp object has")][SerializeField] float healthPoints = 3f;
    [Tooltip("holds reference to ground layer")][SerializeField] LayerMask groundLayer;
    [SerializeField] float deathLength = 1f;
    Vector2 currentCheckpointPos;
    Transform playerTransform;

    UIManager uiManager;
    SoundManager soundManager;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
        soundManager = FindObjectOfType<SoundManager>();
        playerTransform = GetComponent<Transform>();
        if (FindObjectOfType<CheckPointHandler>() != null);
        {
            currentCheckpointPos = FindObjectOfType<CheckPointHandler>().SpawnPoint;
        }

        if (currentCheckpointPos != new Vector2(0,0) && currentCheckpointPos != null)
        {
            gameObject.transform.position = currentCheckpointPos;
        }
    }

    public Vector2 CurrentCheckpointPos
    {
        get => currentCheckpointPos;
        set => currentCheckpointPos = value;
    }


    /// <summary>
    /// player takes damage if enemy or boss is touched, if health left is 0
    /// being death sequence with Die method
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer) { return; }

        if (GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Enemies"))
            || GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Boss")))
        {
            TakeDamage();
        }

        if (healthPoints <= float.Epsilon)
        {
            healthPoints = 0;
            Die();
        }
    }

    /// <summary>
    /// Reduces healthpoints by 1 and updates UI accordingly 
    /// </summary>
    public void TakeDamage()
    {
        healthPoints -= 1f;
        // play damage sound 
        uiManager.UpdatePlayerHealth(healthPoints);
    }


    /// <summary>
    /// when health is 0, handles the death sequence with animations/sonds etc
    /// </summary>
    public void Die()
    {
        // set up animation stuff
        // play death sound 
        uiManager.UpdatePlayerHealth(healthPoints);
        StartCoroutine(DeathSequence());
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    /// <summary>
    /// delays the scene reload on death by a certain amount of time, then reloads
    /// the current level 
    /// </summary>
    /// <returns></returns>
    public IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(deathLength);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        healthPoints = 3f;
        SceneManager.LoadScene(currentSceneIndex);
        uiManager.UpdatePlayerHealth(healthPoints);
    }

}
