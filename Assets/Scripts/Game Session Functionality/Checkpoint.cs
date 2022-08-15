using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Passed { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Controller player = collision.GetComponent<Player_Controller>();
        if (player != null)
        {
            Passed = true;
        }
    }
}
