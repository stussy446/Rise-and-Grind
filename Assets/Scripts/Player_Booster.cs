using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Booster : MonoBehaviour
{

    Rigidbody2D _playerRigidBody;
    Object_BoostValueHolder boostValue;
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
         boostValue = collision.gameObject.GetComponent<Object_BoostValueHolder>();
         ProcessBoost(boostValue);
        
    }

    private void ProcessBoost(Object_BoostValueHolder collisonBoost)
    {
        if (collisonBoost)
        {
            _playerRigidBody.velocity = boostVector * collisonBoost.GetBoostSpeed();

        }
    }
}
