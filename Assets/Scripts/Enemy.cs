using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 2;

    public float jumpForce = 400;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private bool onGround = false;
    private Transform groundCheck;

    private AudioSource audioScr;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("EnemyGroundCheck");
        //audioScr = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (!onGround)
        {
            speed *= -1;
        }

    }


    void FixedUpdate()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (!facingRight && speed > 0)
        {
            Turn();
        }
        else if (facingRight && speed < 0)
        {
            Turn();
        }

    }


    void Turn()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //audioScr.Play();
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            speed = 0;
            transform.Rotate(new Vector3(0, 0, -180));
            //audioScr.Play();
            Destroy(gameObject, 0.5f);
        }

    }


    /*void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().LoseLife();

        }

    }*/
}
