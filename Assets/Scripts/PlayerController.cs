using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;





public class PlayerController : MonoBehaviour
{
    
    public float normalSpeed;

    public float runSpeed;

    public float jumpPower;

    Vector2 moveInput;

    Rigidbody2D myRigid;

    CapsuleCollider2D playerCollider;


    public float dashspeed = 50;

    private bool isDashing = false;

    private bool canDash = true;

    public float dashDuration = 0.1f;

    public float dashCooldown = 1.5f;

    public float climbSpeed = 5;

    Animator animations;


    void Start()
    {
        myRigid = GetComponent<Rigidbody2D> ();
        playerCollider = GetComponent<CapsuleCollider2D>();
        animations = GetComponent<Animator> ();
    }
    void Update()
    {

        if(!isDashing)
        {
        isRunning();
        }
        FlipPlayer();
        OnClimb();

        
        
    }

    void OnMove(InputValue inputValue)
    {
        
        moveInput = inputValue.Get<Vector2>();
        
    }

    void OnJump(InputValue inputValue)
    {
        {
    
        if(inputValue.isPressed)
        {
            myRigid.linearVelocity = new Vector2(myRigid.linearVelocity.x, jumpPower);
            
            
        if(myRigid.linearVelocity.y < 0)
            
            {
                myRigid.gravityScale = 1.5f;
                
            }
        }
        }
    }
    
    void isRunning()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * normalSpeed, myRigid.linearVelocity.y);
        myRigid.linearVelocity = playerVelocity;

        bool isMovingHorizontal = Mathf.Abs(myRigid.linearVelocity.x) > Mathf.Epsilon;

        if(isMovingHorizontal)
        {
            animations.SetBool("isRunning",true);
            animations.SetBool("isIdle",false);
        }
        else
        {
            animations.SetBool("isRunning",false);
            animations.SetBool("isIdle",true);
        }

        

    }
  
    void OnDash(InputValue inputValue)
    {

        if(!isDashing && canDash && playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            StartCoroutine(Dash());
        }
        else
        {
            return;
        }
       
    }

    void OnClimb()
    {
        if(playerCollider.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
        
        Vector2 playerClimb = new Vector2(myRigid.linearVelocity.x, moveInput.y * climbSpeed);
        myRigid.linearVelocity = playerClimb;
        myRigid.gravityScale = 0;
        
        if(playerCollider.IsTouchingLayers(LayerMask.GetMask("Climb")) && myRigid.linearVelocityY > 0)
        {

            bool isNowClimbing = true;
            if(isNowClimbing)
            {
                animations.SetBool("isClimbing",true);
                
            }
            else
            {
                animations.SetBool("isClimbing",false);
                return;
            }
            
        }
        
        }
        else
        {
            myRigid.gravityScale = 10;
            
            
        }

    }

    private IEnumerator Dash()
    {
        
        canDash = false;
        isDashing = true;

        myRigid.linearVelocityX = moveInput.x * dashspeed;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        myRigid.linearVelocity = Vector2.zero;


        yield return new WaitForSeconds(dashCooldown);

        canDash = true;

    }



    void FlipPlayer()
    {
        bool isMovingHorizontal = Mathf.Abs(myRigid.linearVelocity.x) > Mathf.Epsilon;

        if(isMovingHorizontal)
        {

        transform.localScale = new Vector2(Math.Sign(myRigid.linearVelocity.x),1f);

        }
    }

    void AnimationHandler()
    {
        

    }
}
