using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] projectiles;
    [SerializeField] float shotSpeed = 1f;


    public void FireProjectile()
    {
        int projectileToSpawn = Random.Range(0, projectiles.Length - 1);
        GameObject projectile = Instantiate(projectiles[projectileToSpawn], transform.position, Quaternion.identity);
    }


}
