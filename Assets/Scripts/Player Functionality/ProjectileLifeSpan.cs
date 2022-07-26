using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeSpan : MonoBehaviour
{
    [SerializeField] float secondsUntilDeactivation = 4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeactivateProjectile());
    }

    IEnumerator DeactivateProjectile()
    {
        yield return new WaitForSeconds(secondsUntilDeactivation);
        gameObject.SetActive(false);
    }
}
