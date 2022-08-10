using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSwitcher : MonoBehaviour
{

    [SerializeField] GameObject karenDialogueBox;
    [SerializeField] GameObject samDialogueBox;

    Text [] karenLines;
    Text [] samLines;


    // Start is called before the first frame update
    void Start()
    {
        karenLines = karenDialogueBox.GetComponentsInChildren<Text>(includeInactive: true);
        samLines = samDialogueBox.GetComponentsInChildren<Text>(includeInactive: true);
        Debug.Log(samLines[1].text);

    }


    public void SwitchDialogue(Text[] characterLines)
    {
        if (true)
        {
            //yay
        }
    }

    public void StartDialogue()
    {
        Debug.Log("hey:");

        samLines[1].enabled = true; // this needs to be 0 when the dialogue works
    }
}
