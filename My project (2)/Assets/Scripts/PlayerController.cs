using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float gravity = 3;
    public float apexTime = 0.7f;
    public float apexHeight = 3f;
    private float jumpVelocity;
    bool isJumping = false;
    public Rigidbody2D rigidbody;
    public float speed = 7f;
    public float time = 2f;
    public float accleration;
    public float damping = 6f;
    public float maxSpeed = 6f;
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

        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            playerInput.x += 1f;
        }
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            playerInput.x -= 1f;
        }
        if((Keyboard.current.spaceKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            && IsGrounded())
        {
            isJumping = true;
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
         
        }
        else
        {
            rigidbody.linearDamping = damping; //applying friction to stop
        }

        gravity = -2 * apexHeight / (apexTime * apexTime);
        jumpVelocity = 2 * apexHeight / apexTime;
        newVelocity.y += gravity * Time.deltaTime;
        print("Enter");
        if (isJumping)
        {
            print("Enter2");
            newVelocity.y = jumpVelocity;
            isJumping = false;
        }
        rigidbody.linearVelocity = newVelocity;

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
