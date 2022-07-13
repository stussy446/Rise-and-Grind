using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerHandler : MonoBehaviour
{
    [SerializeField] CinemachineSwitcher cinemachineSwitcher;
    [SerializeField] GameObject gate;
    [SerializeField] float delayLength = 1f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        cinemachineSwitcher.SwitchState();
        StartCoroutine(ActivateGate());
        GetComponent<BoxCollider2D>().enabled = false;
    }

    IEnumerator ActivateGate()
    {
        yield return new WaitForSeconds(delayLength);
        gate.SetActive(true);
    }


}
