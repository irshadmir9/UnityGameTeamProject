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



    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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


    }
}
