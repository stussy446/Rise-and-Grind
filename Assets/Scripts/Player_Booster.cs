using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Booster : MonoBehaviour
{
    [SerializeField] int beanLayerIndex = 8; // ideally want to find a better way to do this if time

    Rigidbody2D _playerRigidBody;
    Bean_JumpHeightValues bean;
    Vector2 boostVector = new Vector2(0, 1); // starting vector before it is multiples by boostSpeed
    

    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// if the player collides with a bean, give player a vertical boost based
    /// on that beans boostspeed bonus
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == beanLayerIndex)
        {
            bean = collision.gameObject.GetComponent<Bean_JumpHeightValues>();
            _playerRigidBody.velocity= boostVector * bean.GetBoostSpeed();
        }
    }

}
