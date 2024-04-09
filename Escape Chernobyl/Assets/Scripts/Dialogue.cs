using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject window;
    public List<string> dialogues;
    private int index;
    private int charIndex;

    private bool started;
    public TMP_Text dialogueText;

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    public void StartDialogue()
    {
        if(started)
        {
            return;
        }
        started = true;

        ToggleWindow(true);

        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        index = i;
        charIndex = 0;
        dialogueText.text = string.Empty;
        StartCoroutine (Writing()); 
    }

    public void EndDialogue()
    {

    }
    /*
    IEnumerator Writing()
    {
        string currentDialogue = dialogues[index];
        dialogueText.text += currentDialogue[charIndex];
    }

    */
}
