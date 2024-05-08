using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    public float projectileSpeed = 20;

    public int DelayAmount = 3;
    protected float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            Launch(projectilePrefab);
        }
    }

    void Launch(GameObject prefab)
    {
        var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        float speed = 0;

        if (transform.localPosition.x < 0) 
        { 
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 500); 
        }else 
        {
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * -500);
        }
    }
}
