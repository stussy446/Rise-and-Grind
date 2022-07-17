using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Booster : MonoBehaviour
{

    Rigidbody2D _playerRigidBody;
    Object_BoostValueHolder boostValue;
    Vector2 boostVector = new Vector2(0, 1); 
    Player_Controller _playerController;

    int enemiesLayerMask = 9;

    void Start()
    {
        _playerRigidBody = GetComponentInParent<Rigidbody2D>();
        _playerController = GetComponentInParent<Player_Controller>();

    }


    /// <summary>
    /// if the player collides with a trigger object other than an enemy give player a vertical boost based
    /// on that beans boostspeed bonus
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != enemiesLayerMask)
        {

         boostValue = collision.gameObject.GetComponent<Object_BoostValueHolder>();
         ProcessBoost(boostValue);
        }
        else
        {
            ProcessAttackBoost(collision.gameObject);
        }
        
    }

    /// <summary>
    /// if the player collides with an object other than an enemy give player a vertical boost based
    /// on that beans boostspeed bonus
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != enemiesLayerMask)
        {

            boostValue = collision.gameObject.GetComponent<Object_BoostValueHolder>();
            ProcessBoost(boostValue);
        }
        else
        {
            ProcessAttackBoost(collision.gameObject);
        }
    }


    /// <summary>
    /// takes in a boost value to boost player by and boosts the player based
    /// on that value 
    /// </summary>
    /// <param name="collisonBoost"></param>
    private void ProcessBoost(Object_BoostValueHolder collisonBoost)
    {
        if (collisonBoost)
        {
            _playerRigidBody.velocity = boostVector * collisonBoost.GetBoostSpeed();

        }

    }


    /// <summary>
    /// Takes in an enemy gameObject and applies a boost to the enemy as long as
    /// the player is attacking, otherwise it does nothing
    /// </summary>
    /// <param name="enemy"></param>
    private void ProcessAttackBoost(GameObject enemy)
    {
        
        if (_playerController.GetPlayerIsAttacking() && enemy)
        {
            _playerRigidBody.velocity = boostVector * enemy.GetComponent<Object_BoostValueHolder>().GetBoostSpeed(); 
        }
    }
}
