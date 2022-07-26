using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSystem : MonoBehaviour, ILifeSystem
{

    [Tooltip("amount of hp object has")][SerializeField] float healthPoints = 1f;
    [Tooltip("holds reference to ground layer")][SerializeField] LayerMask groundLayer;
    [SerializeField] float deathLength = .25f;


    public void TakeDamage()
    {
        healthPoints -= 1f;
        // play damage sound 
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
            Die();
        }
    }


    public void Die()
    {
        // set up animation stuff
        // play death sound 
        StartCoroutine(DeathSequence());
    }

    public IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(deathLength);
        // death stuff (animations etc)
        gameObject.SetActive(false);
    }




  
}
