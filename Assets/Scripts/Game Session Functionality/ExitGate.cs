using UnityEngine;

public class ExitGate : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        gameManager.LoadNextLevel();
    }

    public void Activate()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }


}
