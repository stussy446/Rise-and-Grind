using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] projectiles;
    [SerializeField] float xShotSpeed = 1f;
    [SerializeField] float yShotSpeed = 1f;



    public void FireProjectile()
    {
        int projectileToSpawn = Random.Range(0, projectiles.Length);
        GameObject projectile = Instantiate(projectiles[projectileToSpawn], transform.position, transform.rotation);
        Vector3 shotForce = new Vector3(xShotSpeed, yShotSpeed, 0);
        projectile.GetComponent<Rigidbody2D>().AddRelativeForce(shotForce);
    }


}
