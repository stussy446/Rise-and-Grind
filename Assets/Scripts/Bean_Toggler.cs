using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean_Toggler : MonoBehaviour
{

    [Tooltip("seconds until bean reactivates")]
    [SerializeField] float secondsUntilReactivation = 3f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(ReactivateBean());
        
    }

    /// <summary>
    /// Called in Trigger function. Waits for set amount of seconds and then
    /// reactivates the object's collider and sprite renderer
    /// </summary>
    /// <returns></returns>
    IEnumerator ReactivateBean()
    {
        yield return new WaitForSeconds(secondsUntilReactivation);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
