using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammericon : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMove e = collision.collider.GetComponent<PlayerMove>();
        if (e != null)
        {
            e.setAxe(false);
            e.setHammer(true);
        }
        Destroy(gameObject);
    }
}
