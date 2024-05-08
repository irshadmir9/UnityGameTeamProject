using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthcollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove controller = collision.GetComponent<PlayerMove>();
        if (controller != null)
        {
            controller.ChangeHealth(30);
            Destroy(gameObject, 3);
        }

        

    }
}
