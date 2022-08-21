using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    TMP_Text lifeText;
    TMP_Text scoreText;
    int score = 0;

    public int GetScore { get => score; }

    /// <summary>
    /// prevents more than one UI Manager from being active at a time 
    /// </summary>
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
       scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();

    }


    /// <summary>
    /// updates the score ui to reflect the score added from player collectible
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "= " + score;
    }

    /// <summary>
    /// updates player health ui to reflect amount of health player has remaining 
    /// </summary>
    /// <param name="healthRemaining"></param>
    public void UpdatePlayerHealth(float healthRemaining)
    {
        if (healthRemaining >= 0)
        {
            lifeText.text = "= " + healthRemaining;
        }
    }
}
