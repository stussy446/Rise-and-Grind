using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour, ILifeSystem
{
    [Tooltip("amount of hp object has")][SerializeField] float healthPoints = 2f;
    [Tooltip("holds reference to ground layer")][SerializeField] LayerMask groundLayer;

    [SerializeField] float deathLength = 1f;
    [SerializeField] CapsuleCollider2D damageTakingCollider;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
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

        if (damageTakingCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
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
        Destroy(gameObject);
    }

    
}
