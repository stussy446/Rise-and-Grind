using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;

public class EnableMainMenu : MonoBehaviour
{

    [SerializeField] PlayableDirector director;

    void Update()
    {
        if (director.time >= director.duration)
        {
            GetComponent<Button>().image.enabled = true;
            GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        } 
    }
}
