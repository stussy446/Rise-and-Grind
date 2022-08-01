using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] projectiles;
    [SerializeField] float xShotSpeed = 1f;
    [SerializeField] float yShotSpeed = 1f;
    Player_Controller player;
    Vector2 shotForce;

    private void Start()
    {
        player = FindObjectOfType<Player_Controller>();
    }


    /// <summary>
    /// called when the fire button is pressed (See Player Controller Script)
    /// chooses random projectile object and shoots it based on the direction
    /// that the player is currently facing
    /// </summary>
    public void FireProjectile()
    {
        int projectileToSpawn = Random.Range(0, projectiles.Length);
        GameObject projectile = Instantiate(projectiles[projectileToSpawn], transform.position, transform.rotation);

        //if (player.transform.localScale.x == -1)
        //{
        //    shotForce = new Vector3(-xShotSpeed, yShotSpeed, 0);

        //}
        //else
        //{
        //    shotForce = new Vector3(xShotSpeed, yShotSpeed, 0);

        //}
        shotForce = new Vector3(xShotSpeed, yShotSpeed, 0);

        projectile.GetComponent<Rigidbody2D>().AddRelativeForce(shotForce);

    }


}
