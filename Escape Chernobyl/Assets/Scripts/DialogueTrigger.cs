using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool playerDetected;
    public Dialogue dialogueScript;
    public PlayerMove player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove controller = collision.GetComponent<PlayerMove>();
        
        if (collision.tag == "Player")
        { 
            playerDetected = true;

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
            player.flag++;
            Debug.Log(player.flag); 
            dialogueScript.StartDialogue();
        }
    }
}
