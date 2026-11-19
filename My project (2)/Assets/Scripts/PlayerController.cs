using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed = 7f;
    public float time = 2f;
    private float accleration;
    public float damping = 6f;
    public float maxSpeed = 14f;
    public float rayLength = 1f;
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

        RaycastHit2D hitGroundLeft = Physics2D.Raycast(transform.position + new Vector3(-0.1f, -0.6f,0), Vector2.down, rayLength, 5);
        //RaycastHit2D hitGroundRight = Physics2D.Raycast(transform.position + new Vector3(0.1f, 0,0), Vector2.down, rayLength, 5);
        if (hitGroundLeft.collider != null)
        {
            print(hitGroundLeft.collider.name);
            return true;
        }
        else
        {
            print("False");
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
