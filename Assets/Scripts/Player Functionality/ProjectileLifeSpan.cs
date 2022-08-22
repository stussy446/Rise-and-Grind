using System.Collections;
using UnityEngine;

public class ProjectileLifeSpan : MonoBehaviour
{
    [SerializeField] float secondsUntilDeactivation = 4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeactivateProjectile());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Enemies"))
               || GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Boss")))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }


    IEnumerator DeactivateProjectile()
    {
        yield return new WaitForSeconds(secondsUntilDeactivation);
        gameObject.SetActive(false);
    }
}
