using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class DialogueSwitcher : MonoBehaviour
{

    [SerializeField] GameObject karenDialogueBox;
    [SerializeField] GameObject samDialogueBox;

    PlayerControls dialogueControls;

    Text [] karenLines;
    Text [] samLines;

    int currentKarenLine = 0;
    int currentSamLine = 0;
    int totalLines;
    int currentLineCount = 0;

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


    }

    private void OnEnable()
    {
        dialogueControls = new PlayerControls();
        dialogueControls.UI.Enable();
        dialogueControls.UI.GoToNextLineOfDialogue.performed += SwitchDialogue;
    }

   
    private void OnDisable()
    {
        dialogueControls.UI.Disable();
        dialogueControls.UI.GoToNextLineOfDialogue.performed -= SwitchDialogue;

    }



    public void StartDialogue()
    {

        samLines[0].enabled = true; // this needs to be 0 when the dialogue works
        Debug.Log(samLines[currentSamLine].text);
        currentCharacter = "Sam";
    }


    private void SwitchDialogue(InputAction.CallbackContext obj)
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
        Debug.Log("Scene over");
        dialogueControls.Disable();
        
    }

    private void SwitchToKaren()
    {
        Debug.Log(karenLines[currentKarenLine].text);
        currentCharacter = "Karen";
        //Debug.Log("Sams current line:" + samLines[currentSamLine].text);
        //Debug.Log("Karens current line:" + karenLines[currentSamLine].text);

        samLines[currentSamLine].enabled = false;
        karenLines[currentKarenLine].enabled = true;
        currentSamLine++;
    }

    private void SwitchToSam()
    {
        currentCharacter = "Sam";
        Debug.Log(currentSamLine);
        Debug.Log(samLines[currentSamLine].text);
        samLines[currentSamLine].enabled = true;
        karenLines[currentKarenLine].enabled = false;
        currentKarenLine++;
    }

}
