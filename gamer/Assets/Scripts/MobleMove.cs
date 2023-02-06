using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MobleMove : MonoBehaviour
{
    int mobileinput=0;
    [SerializeField]
    float moveSpeed = 1.0f;
    public GameObject prefab;
    Rigidbody2D rb;
    [SerializeField]
    float jumpSpeed = 1.0f;
    bool grounded = false;
    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int moveDir = 0;
        int keyboardinput = (int)Input.GetAxisRaw("Horizontal");
        moveDir = keyboardinput + mobileinput;
        moveDir = Mathf.Clamp(moveDir, -1, 1);
        Vector2 volocity = rb.velocity;
        volocity.x = moveDir * moveSpeed;
        rb.velocity = volocity;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }
        if (rb.velocity.y < -0.1f && !grounded)
        {
            animator.SetTrigger("PFall");
        }
        animator.SetFloat("xInput", moveDir);
        animator.SetBool("grounded", grounded);
        if (moveDir < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;

        }
        if (moveDir > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }
    }
    private void FixedUpdate()
    {
        
    }
    public void UpdateMoveDirectiom(int direction)
    {
        mobileinput = direction;
    }
    public void Jump()
    {
        if (grounded)
        {
            grounded = false;
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            animator.SetTrigger("PlayerJump");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}
