using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerHandler : MonoBehaviour
{
    [SerializeField] CinemachineSwitcher cinemachineSwitcher;
    [SerializeField] GameObject[] gates;
    [SerializeField] float delayLength = 1f;
    [SerializeField] GameObject karen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        cinemachineSwitcher.SwitchState();
        if (gates.Length > 0)
        {
            StartCoroutine(ActivateGates());

        }
        GetComponent<BoxCollider2D>().enabled = false;
        karen.SetActive(true);
    }

    IEnumerator ActivateGates()
    {
        yield return new WaitForSeconds(delayLength);
        foreach (var gate in gates)
        {
            gate.SetActive(true);

        }
    }


}
