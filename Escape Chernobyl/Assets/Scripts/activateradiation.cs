using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class activateradiation : MonoBehaviour
{
    public GameObject[] radiation;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        for (int i = 0; i < radiation.Length; i++)
        {
            radiation[i].SetActive(true);
        }

    }
}
