using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Booster : MonoBehaviour
{
    [SerializeField] float boostSpeed = 1f;
    [SerializeField] int beanLayerIndex = 8;
    Rigidbody2D _playerRigidBody;


    void Awake()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// if the player collides with a bean, give player a vertical boost
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == beanLayerIndex)
        {
            _playerRigidBody.AddForce(Vector2.up * boostSpeed);
        }
    }

}
