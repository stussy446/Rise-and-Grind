using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


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
    UIManager uiManager;


    public UnityEvent onTutorialStart;
    public UnityEvent onMoveTutorialEnd;


    private void Start()
    {
        if (onTutorialStart == null)
        {
            onTutorialStart = new UnityEvent();
        }

        if (onMoveTutorialEnd == null)
        {
            onMoveTutorialEnd = new UnityEvent();
        }

        onTutorialStart?.Invoke();

        textPopUps[0].gameObject.SetActive(true);
        currentMessageIndex = 0;

        for (int i = 1; i < textPopUps.Length; i++)
        {
            textPopUps[i].gameObject.SetActive(false);
        }

        playerController = FindObjectOfType<Player_Controller>();
        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();

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

        if (PlayerTouchedBean())
        {
            NextTutorial();
        }

        if (PlayerTouchedGoldenBean())
        {
            NextTutorial();
        }

        if (PlayerCollected())
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

    bool PlayerTouchedBean()
    {
        if (playerController.BeanTouched && popUpIndex == 3)
        {
          
            return true;
        }
        return false;
    }

    bool PlayerTouchedGoldenBean()
    {
       
        if (playerController.GoldenBeanTouched && popUpIndex == 4)
        {
            return true;
        }
        return false;
    }

    bool PlayerCollected()
    {
        if (uiManager.GetScore > 0 && popUpIndex == 5)
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

        if (popUpIndex == 4)
        {
            yield return new WaitForSeconds(secondsToWait);
            
        }
    
        else if (popUpIndex == 3)
        {
            yield return new WaitForSeconds(secondsToWait);
            GameObject[] beans = GameObject.FindGameObjectsWithTag("Bean");
            foreach (GameObject bean in beans)
            {
                bean.GetComponent<SpriteRenderer>().enabled = true;
                bean.GetComponent<CapsuleCollider2D>().enabled = true;
            }

        }
        else if (popUpIndex == 1)
        {
            yield return new WaitForSeconds(secondsToWait);
            onMoveTutorialEnd?.Invoke();
        }
        else if (popUpIndex == 2)
        {
            yield return new WaitForSeconds(secondsToWait);
            playerController.EnableAttack();

        }
        else
        {
            yield return new WaitForSeconds(secondsToWait);
        }

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

