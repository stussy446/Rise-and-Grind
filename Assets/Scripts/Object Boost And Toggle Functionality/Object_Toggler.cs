using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Toggler : MonoBehaviour
{

    [Tooltip("seconds until object reactivates")]
    [SerializeField] float secondsUntilReactivation = 3f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessToggle();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessToggle();

    }

    /// <summary>
    /// deactivates sprite renderer and capsule collider, and calls coroutine
    /// responsible for reactivating them
    /// </summary>
    private void ProcessToggle()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(ReactivateSpriteAndCollider());

    }

    /// <summary>
    /// Called in Trigger and Collision functions. Waits for set amount of seconds and then
    /// reactivates the object's collider and sprite renderer
    /// </summary>
    /// <returns></returns>
    IEnumerator ReactivateSpriteAndCollider()
    {
        yield return new WaitForSeconds(secondsUntilReactivation);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
