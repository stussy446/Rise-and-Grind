using System.Collections;
using UnityEngine;

public class LifeSystem : MonoBehaviour, ILifeSystem
{
    [Tooltip("amount of hp object has")][SerializeField] float healthPoints = 2f;
    [Tooltip("holds reference to ground layer")][SerializeField] LayerMask groundLayer;

    [SerializeField] float deathLength = 1f;
    [SerializeField] CapsuleCollider2D damageTakingCollider;

    Animator animator;
    PlayerLifeSystem player;
    Vector2 startingPos;


    private void Awake()
    {
        player = FindObjectOfType<PlayerLifeSystem>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerLifeSystem>();
        startingPos = GetComponent<Transform>().position;
        gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        player.onPlayerDeath += ResetBoss;
    }

    private void OnDisable()
    {
        player.onPlayerDeath -= ResetBoss;
    }


    private void ResetBoss()
    {
        GetComponent<Transform>().position = startingPos;
        gameObject.SetActive(false);
    }


    /// <summary>
    /// on trigger collision, subtrack health, if the health is less than 0 have
    /// object enter the Die State
    /// </summary>
    /// <param name="collision"></param>
    ///
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer) { return; }

        if (damageTakingCollider.IsTouchingLayers(LayerMask.GetMask("Projectile")))
        {
            TakeDamage();
        }

        if (healthPoints <= float.Epsilon)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(DeathSequence());
    }

    public void TakeDamage()
    {
        healthPoints -= 1f;
        animator.SetTrigger("TakeHit");
    }


    public IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(deathLength);
        if (gameObject.CompareTag("Boss"))
        {
            FindObjectOfType<ExitGate>().Activate();
        }


        Destroy(gameObject);
    }


  
    

    
}
