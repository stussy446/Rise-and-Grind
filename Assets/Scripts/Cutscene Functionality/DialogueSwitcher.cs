using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class DialogueSwitcher : MonoBehaviour
{

    [SerializeField] GameObject karenDialogueBox;
    [SerializeField] GameObject samDialogueBox;
    [SerializeField] GameObject nextLineButton;

    PlayerControls dialogueControls;
    PlayableDirector director;

    Text [] karenLines;
    Text [] samLines;

    int currentKarenLine = 0;
    int currentSamLine = 0;
    int totalLines;
    int currentLineCount = 0;
    [SerializeField] float secondsToWait = 1f;

    string currentCharacter;


    // Start is called before the first frame update
    void Start()
    {
        karenLines = karenDialogueBox.GetComponentsInChildren<Text>(includeInactive: true);
        samLines = samDialogueBox.GetComponentsInChildren<Text>(includeInactive: true);

        totalLines = karenLines.Length + samLines.Length;

        foreach(Text line in samLines)
        {
            line.enabled = false;
        }

        foreach (Text line in karenLines)
        {
            line.enabled = false;
        }

        nextLineButton.SetActive(false);


    }

    private void OnEnable()
    {
        dialogueControls = new PlayerControls();
    }

   
    private void OnDisable()
    {
        dialogueControls.UI.Disable();

    }



    public void StartDialogue()
    {
        dialogueControls.UI.Enable();
        nextLineButton.SetActive(true);
        samLines[0].enabled = true; 
        currentCharacter = "Sam";
    }

    public void ButtonSwitchDialogue()
    {
        if (currentSamLine == totalLines / 2)
        {
            EndScene();
            return;
        }

        if (currentLineCount < totalLines && currentCharacter == "Sam")
        {
            SwitchToKaren();
        }
        else if (currentLineCount < totalLines && currentCharacter == "Karen")
        {
            SwitchToSam();
        }

        currentLineCount++;

    }


    private void EndScene()
    {
        dialogueControls.UI.Disable();
        if (GameObject.FindGameObjectWithTag("Finish").GetComponent<PlayableDirector>() != null)
        {
            director = GameObject.FindGameObjectWithTag("Finish").GetComponent<PlayableDirector>();
        }
        StartCoroutine(GoToTutorial());
        
    }

    IEnumerator GoToTutorial()
    {
        yield return new WaitForSeconds(secondsToWait);
        SoundManager.instance.ResetSound();
        FindObjectOfType<GameManager>().LoadNextLevel();
        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }

    private void SwitchToKaren()
    {
        currentCharacter = "Karen";

        samLines[currentSamLine].enabled = false;
        karenLines[currentKarenLine].enabled = true;
        currentSamLine++;
    }

    private void SwitchToSam()
    {
        currentCharacter = "Sam";
        samLines[currentSamLine].enabled = true;
        karenLines[currentKarenLine].enabled = false;
        currentKarenLine++;
    }

}
