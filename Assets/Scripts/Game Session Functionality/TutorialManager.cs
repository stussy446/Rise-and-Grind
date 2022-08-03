using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text[] textPopUps;
    public string[] congratulatoryMessages;
    int popUpIndex = 0;
    int currentMessageIndex;
    [SerializeField] float secondsToWait = 2f;
    [SerializeField] ExitGate exitGate;

    Player_Controller playerController;
    GameManager gameManager;

    private void Start()
    {
        textPopUps[0].gameObject.SetActive(true);
        currentMessageIndex = 0;

        for (int i = 1; i < textPopUps.Length; i++)
        {
            textPopUps[i].gameObject.SetActive(false);
        }

        playerController = FindObjectOfType<Player_Controller>();
        gameManager = FindObjectOfType<GameManager>();

    }


    private void Update()
    {
        if (PlayerMoved())
        {
            NextTutorial();
        }

        if (PlayerJumped())
        {
            NextTutorial();
        }

        if (PlayerAttacked())
        {
            NextTutorial();
        }


        CheckForEndOfTutorial();
    }


    bool PlayerMoved()
    {

        if (playerController.GetMoveInputValue() != 0 && popUpIndex == 0)
        {
            return true;
        }

        return false;
    }


    bool PlayerJumped()
    {
        if (!playerController.IsGrounded() && popUpIndex == 1)
        {
            return true;
        }
        return false;
    }

    bool PlayerAttacked()
    {
        if (playerController.GetPlayerIsAttacking() && popUpIndex == 2)
        {
            return true;
        }
        return false;
    }


    void NextTutorial()
    {
        textPopUps[popUpIndex].text = congratulatoryMessages[currentMessageIndex];
        popUpIndex++;
        currentMessageIndex++;
        StartCoroutine(DelaySwitch());
        
    }

    IEnumerator DelaySwitch()
    {
        yield return new WaitForSeconds(secondsToWait);
        textPopUps[popUpIndex - 1].gameObject.SetActive(false);

        textPopUps[popUpIndex].gameObject.SetActive(true);
    }


    void CheckForEndOfTutorial()
    {
        if (popUpIndex == textPopUps.Length - 1)
        {
            exitGate.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }

}

