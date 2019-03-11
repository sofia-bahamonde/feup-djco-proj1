using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool jump = false;
    private Animator anim;
    private bool onGround = false;
    private Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && onGround)
        {
            jump = true;
            anim.SetTrigger("Jump");
        }

    }

    void FixedUpdate()
    {
        float horizontalkey = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Velocity", Mathf.Abs(horizontalkey));
        rb.velocity = new Vector2(horizontalkey * speed, rb.velocity.y);

        if (horizontalkey > 0 && !facingRight)
        {
            Turn();
        }
        else if (horizontalkey < 0 && facingRight)
        {
            Turn();
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }


    void Turn()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
