using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeicon : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMove e = collision.collider.GetComponent<PlayerMove>();
        if (e != null)
        {
            e.setAxe(true);
            e.setCrowbar(false);
        }
        Destroy(gameObject);
    }
}
