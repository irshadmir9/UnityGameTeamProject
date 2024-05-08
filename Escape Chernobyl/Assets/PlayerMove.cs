using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb2d;

    public Animator animator;
    public bool isJumping = false;


    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10;

    float horizontal;
    float vertical;
    public bool crowbar = false;
    public bool axe = false;
    public bool hammer = false;

    public int maxHealth = 600;
    public int currentHealth = 600;

    public int DelayAmount = 1;
    protected float Timer;

    public int flag;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            currentHealth = 600;
        }
        else { currentHealth = PlayerPrefs.GetInt("health"); }

        flag = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 2)
        {
            Timer += Time.deltaTime;
            if (Timer >= DelayAmount)
            {
                Timer = 0f;
                ChangeHealth(-1);
            }
        }
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);




        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;




        animator.SetFloat("Speed", Mathf.Abs(moveInput * moveSpeed));

        if (Mathf.Abs(rb2d.velocity.y) > 0.001)
        {
            isJumping = true;
        } else
        {
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb2d.velocity.y) < 0.001)
        {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (isJumping)
        {
            animator.SetBool("isJumping", true);
        } else
        {
            animator.SetBool("isJumping", false);
        }

        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }

        if (Input.GetKey(KeyCode.Space)&& (rb2d.velocity.y) < 0)
        {
            rb2d.gravityScale = -0.1f;

        }
        else
        {
            rb2d.gravityScale = 3;
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (Input.GetKeyDown(KeyCode.L) && crowbar)
        {
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            float speed = 0;
            if(transform.localScale == new Vector3(4, 4, 4))
            {
                speed = projectileSpeed;
            }
            else { speed = -projectileSpeed; }

            projectile.GetComponent<Rigidbody2D>().velocity = projectileSpawnPoint.right * speed;
            
        }
        if (Input.GetKeyDown(KeyCode.L) && axe)
        {
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            float speed = 0;
            if (transform.localScale == new Vector3(4, 4, 4))
            {
                speed = projectileSpeed;
            }
            else { speed = -projectileSpeed; }

            projectile.GetComponent<Rigidbody2D>().velocity = projectileSpawnPoint.right * speed;

        }

        if (Input.GetKeyDown(KeyCode.L) && hammer)
        {
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            float speed = 0;
            if (transform.localScale == new Vector3(4, 4, 4))
            {
                speed = projectileSpeed;
            }
            else { speed = -projectileSpeed; }

            projectile.GetComponent<Rigidbody2D>().velocity = projectileSpawnPoint.right * speed;

        }

        if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            PlayerPrefs.SetInt("health", currentHealth);
        }
        

    }

    public void setCrowbar(bool c)
    {
        crowbar = c;
    }
    public void setAxe(bool a)
    {
        axe = a;
    }
    public void setHammer(bool h)
    {
        hammer = h;
    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
