using System.Collections;
using UnityEngine;

public class EnemyLifeSystem : MonoBehaviour, ILifeSystem
{

    [Tooltip("amount of hp object has")][SerializeField] float healthPoints = 1f;
    [Tooltip("holds reference to ground layer")][SerializeField] LayerMask groundLayer;
    [SerializeField] float deathLength = .25f;
    GameObject verticalCamera;
    GameObject horizontalCamera;
    ParticleSystem pSystem;

    private void Awake()
    {
        verticalCamera = GameObject.FindGameObjectWithTag("Vertical Camera");
        horizontalCamera = GameObject.FindGameObjectWithTag("Horizontal Camera");
        pSystem = GetComponentInChildren<ParticleSystem>();

    }


    public void TakeDamage()
    {
        SoundManager.instance.PlayPartOfSound("ProjectileBreak", 0.35f);
        healthPoints -= 1f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer) { return; }

        if (GetComponent<PolygonCollider2D>().IsTouchingLayers(LayerMask.GetMask("Projectile")))
        {
            TakeDamage();
        }

        if (healthPoints <= float.Epsilon)
        {
            if (pSystem != null)
            {
                pSystem.Play();
            }
            Die();
        }
    }


    public void Die()
    {
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        verticalCamera.GetComponent<CinemachineShake>().ShakeCamera(2f, .25f);
        horizontalCamera.GetComponent<CinemachineShake>().ShakeCamera(2f, .25f);
        SoundManager.instance.PlayPartOfSound("EnemyDeath", 0.25f);
        StartCoroutine(DeathSequence());
    }

    public IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(deathLength);
        if (pSystem != null)
        {
            pSystem.Stop();
        }
        gameObject.SetActive(false);
    }




  
}
