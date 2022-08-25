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

    PlayerLifeSystem player;
    int switchCount = 0;


    private void Awake()
    {
        player = FindObjectOfType<PlayerLifeSystem>();
    }
    private void Start()
    {
        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].SetActive(false);
        }
       
    }

    private void OnEnable()
    {
        player.onPlayerDeath += ResetGates;
    }


    private void OnDisable()
    {
        player.onPlayerDeath -= ResetGates;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (switchCount == 0)
        {
            cinemachineSwitcher.SwitchState();
            switchCount++;
        }
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


    private void ResetGates()
    {
        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].SetActive(false);
        }

        GetComponent<BoxCollider2D>().enabled = true;

    }


}
