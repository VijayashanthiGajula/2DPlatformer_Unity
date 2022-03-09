using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    [SerializeField] SpriteRenderer sprite;//glitch when player flips-collider box
    public float speed = 5f;
    public float runSpeed = 10f;
    public float jumpforce = 5f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] float x;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(x));
        if (x != 0)
        {
            Walk(); //arrow keys right, left
        }
        if (Input.GetButtonDown("Jump") && isGrounded)//space
        {
            Jump();
        }
        // if (Input.GetButtonDown("Fire3"))
        // {
        //     Run();
        // }
    }
    private void Walk()
    {
        sprite.flipX = (x < 0);//conditional stmt to assign true if x<0
                               //---if player moves negative x side then sprite will be flipped here
        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x, rb.velocity.y);

            // Debug.Log("Walk speed " + x);

    }
    // private void Run()
    // {
    //     Debug.Log(x);
    //     x = Input.GetAxisRaw("Fire3");
    //     sprite.flipX = (x < 0);
    //      x = x * runSpeed;
    //     animator.SetFloat("Speed", Mathf.Abs(x));
    //     rb.velocity = new Vector2(x, rb.velocity.y);
      
    // }

    private void Jump()
    {
        isGrounded = false;
         animator.SetBool("IsJumping", true);
         // animator.SetTrigger("IsJump");
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
       // Debug.Log("jump event  isGrounded " + isGrounded);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
           //  Debug.Log("collision event  "  );
            animator.SetBool("IsJumping", false);
         
        }


    }
}
