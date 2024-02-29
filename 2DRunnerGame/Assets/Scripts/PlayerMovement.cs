using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;
    private Animator animator;
    private SpriteRenderer sr;


    float dirX = 0f;
   [SerializeField] private float moveSpeed = 7.0f;
   [SerializeField] private float jumpForce = 7.0f;

    private enum MovementState{idle,running,jumping,falling}
    

   
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        coll=GetComponent<BoxCollider2D>();
        animator=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
         dirX = Input.GetAxis("Horizontal");
        rb.velocity=new Vector2(dirX*moveSpeed,rb.velocity.y);


        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce) ;
            jumpSoundEffect.Play();
        }
        UpdateAnimation();
        
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0)
        {
            state = MovementState.running;
            sr.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sr.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;


        }
        else if(rb.velocity.y<-.1f)
        {
           state=MovementState.falling;
        }
        animator.SetInteger("states", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down,.1f, jumpableGround);
    }
}
