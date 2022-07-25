using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : MonoBehaviour, ILifeSystem
{
    [Tooltip("amount of hp object has")][SerializeField] float healthPoints = 3f;
    [Tooltip("holds reference to ground layer")][SerializeField] LayerMask groundLayer;
    [SerializeField] float deathLength = 1f;

    UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

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
            Die();
        }
    }

    public void TakeDamage()
    {
        healthPoints -= 1f;
        Debug.Log("health left : " + healthPoints);
    }


    public void Die()
    {
        // set up animation stuff
        StartCoroutine(DeathSequence());
    }


    public IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(deathLength);
        Debug.Log("Died!");
    }

}
