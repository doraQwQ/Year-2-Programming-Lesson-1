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
    public float maxSpeed = 8f;
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
        Debug.Log(playerInput.x);
        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newVelocity=rigidbody.linearVelocity;   //collision can affect linear velocity
        if (playerInput.x != 0)
        {
            newVelocity += playerInput.x* Vector2.right* accleration* Time.deltaTime;
        }
        else
        {

        }
        rigidbody.linearVelocity = newVelocity;





    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
