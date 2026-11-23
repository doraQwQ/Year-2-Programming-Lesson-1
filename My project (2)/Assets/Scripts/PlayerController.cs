using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float gravity = 3;
    public float apexTime = 0.3f;
    public float apexHeight = 1.5f;
    private float jumpVelocity;
    public Rigidbody2D rigidbody;
    public float speed = 7f;
    public float time = 2f;
    private float accleration;
    public float damping = 6f;
    public float maxSpeed = 14f;
    public float rayLength = 0.67f;
    public LayerMask groundLayer;
    private FacingDirection PreviousFacing=FacingDirection.right;
    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        accleration = maxSpeed / time;
    }

    // Update is called once per frame
    void Update()
    {     
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.

        Vector2 playerInput = new Vector2();

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x += 1f;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x -= 1f;
        }
        if (Keyboard.current.spaceKey.isPressed)
        {
            playerInput.y += 1;
        }
        else//reset condition
        {
            playerInput.y = 0;
        }
        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newVelocity=rigidbody.linearVelocity;   //collision can affect linear velocity
        if (playerInput.x != 0)
        {
            rigidbody.linearDamping = 0;    //reset the damping effect
            newVelocity += playerInput.x* Vector2.right* accleration* Time.deltaTime;
            rigidbody.linearVelocity = newVelocity;
        }
        else
        {
            rigidbody.linearDamping = damping; // applying friction to stop
        }
        if (IsGrounded() && playerInput.y != 0)
        {
            gravity = -2*apexHeight /(apexTime * apexTime);
            jumpVelocity = 2*apexHeight / apexTime;
            Vector2 currentVelocity = new Vector2(rigidbody.linearVelocity.x, jumpVelocity);
            rigidbody.linearVelocity= currentVelocity;
        }

        
    }

    public bool IsWalking()
    {
        if (Keyboard.current.rightArrowKey.isPressed|| Keyboard.current.leftArrowKey.isPressed)
        {
            return true;
        }
        else
        {
            return false;
        }
     
    }
    public bool IsGrounded()
    {
        RaycastHit2D hitGroundLeft = Physics2D.Raycast(transform.position + new Vector3(-0.2f, 0,0),
            Vector2.down, rayLength, groundLayer);
        RaycastHit2D hitGroundRight = Physics2D.Raycast(transform.position + new Vector3(0.2f, 0,0),
            Vector2.down, rayLength, groundLayer);
        if (hitGroundLeft&& hitGroundRight)
        {
            
            return true;
        }
        else
        {
            return false;
        }   
        
    }

    public FacingDirection GetFacingDirection()
    {  
        //tried linear velocity, but fails.
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            PreviousFacing = FacingDirection.right;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            PreviousFacing = FacingDirection.left;
        }
        return PreviousFacing;
    }
}
