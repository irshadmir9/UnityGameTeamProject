using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool playerDetected;
    public AudioSource DoorEnter;


    public bool enough = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove controller = collision.GetComponent<PlayerMove>();
        if (controller != null)
        {
            if (controller.flag > 5)
            {
                enough = true;
            }
        }

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
            if (playerDetected && Input.GetKeyDown(KeyCode.Q)&&enough)
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
