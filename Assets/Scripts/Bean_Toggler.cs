using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean_Toggler : MonoBehaviour
{

    float _timeDeactiated;
    [Tooltip("seconds until bean reactivates")]
    [SerializeField] float secondsUntilReactivation = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(ReactivateBean());
        
    }

    IEnumerator ReactivateBean()
    {
        yield return new WaitForSeconds(secondsUntilReactivation);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
