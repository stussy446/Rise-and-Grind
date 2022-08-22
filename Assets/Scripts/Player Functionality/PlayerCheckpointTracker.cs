using UnityEngine;

public class PlayerCheckpointTracker : MonoBehaviour
{
    ScenePersist currentScene;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = FindObjectOfType<ScenePersist>();
        playerTransform = GetComponent<Transform>();


        if (currentScene.FirstLife == true)
        {
            currentScene.FirstLife = false;
            GameObject startingCheckpoint = GameObject.FindGameObjectWithTag("Starting Checkpoint");
            playerTransform.position = startingCheckpoint.transform.position;
            currentScene.CurrentCheckpointPos = playerTransform.position;
        }
        else
        {
            Debug.Log("players position: " + playerTransform.position);
            Debug.Log("scene persist position: " + currentScene.CurrentCheckpointPos);
            playerTransform.position = currentScene.CurrentCheckpointPos;
        }
    
    }


}
