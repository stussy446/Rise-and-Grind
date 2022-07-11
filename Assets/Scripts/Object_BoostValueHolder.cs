using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_BoostValueHolder : MonoBehaviour
{
    [SerializeField] float boostSpeed = 1f;

    public float GetBoostSpeed() { return boostSpeed;}
}
