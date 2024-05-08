using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    private bool playerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove controller = collision.GetComponent<PlayerMove>();
        if(controller != null)
        {
            controller.ChangeHealth(-20);
        }

        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // Update is called once per frame

    }
}