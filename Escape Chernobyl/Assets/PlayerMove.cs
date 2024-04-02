using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb2d;

    public Animator animator;
    public bool isJumping = false;

    Vector2 lookDirection = new Vector2(1, 0);

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

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;
        



        animator.SetFloat("Speed", Mathf.Abs(moveInput * moveSpeed));

        if (Mathf.Abs(rb2d.velocity.y) > 0.001)
        {
            isJumping = true;
        }else
        {
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb2d.velocity.y) < 0.001)
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
            transform.localScale = new Vector3(-4,4,4);
        }
        if(moveInput > 0)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("hi");
            RaycastHit2D hit = Physics2D.Raycast(rb2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
            }
        }
    }
}
