using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool playerDetected;
    public AudioSource DoorEnter;
    public PlayerMove flags;

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
        if(SceneManager.GetActiveScene().buildIndex>1)
        {
            if (playerDetected && Input.GetKeyDown(KeyCode.Q)&&flags.flag==5)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



            }
        } else
        {
            if (playerDetected && Input.GetKeyDown(KeyCode.Q))
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);



            }
        }
        
    }
}
