using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutsceneLoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextLevel()
    {
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene(0);

    }
}
