using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool playerDetected;
    public AudioSource DoorEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            playerDetected = true;
            DoorEnter.Play();
        }


    }

    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.Q))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            


        }
    }
}
