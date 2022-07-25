using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] TMP_Text scoreText;
    TMP_Text lifeText;
    int score = 0;

    private void Awake()
    {
        // singleton pattern to make sure only one UIManager persists per scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
       lifeText = GameObject.Find("Life Text").GetComponent<TMP_Text>();
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "= " + score;
    }

    public void UpdatePlayerHealth(float healthRemaining)
    {
        lifeText.text = "= " + healthRemaining;
    }
}
