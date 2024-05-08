using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool playerDetected;
    public Dialogue dialogueScript;
    public PlayerMove flagcount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            playerDetected = true;
            flagcount.flag++;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.tag == "Player")
        {
            playerDetected = false; 
        }
    }

    private void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }
}
