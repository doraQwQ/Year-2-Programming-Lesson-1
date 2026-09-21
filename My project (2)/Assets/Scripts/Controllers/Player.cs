using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //Enemy enemy= GetComponent<Enemy>;
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 bombOffset;
    public Vector2 spawnOffset;
    public float x;
    public float y;
    public GameObject bombInstantation;
    public List<GameObject> bombs = new List<GameObject>();
    bool IsUpperLeftCornerEmpty = true, IsLowerLeftCornerEmpty = true,
         IsLowerRightCornerEmpty = true, IsUpperRightCornerEmpty = true;
    public Vector3 currentVelocity = Vector3.right;
    public Vector3 velocity1 = Vector3.up;
    public Vector3 velocity2 = Vector3.left;
    public Vector3 velocity3 = Vector3.down;
    public Vector3 velocity4 = Vector3.right;
    public float speed=1;
    public float accelerationTime=3f;
    public float currentAcceleration;
    public float maxSpeed;
    public float deceleration;
    public float decelerationTime;
    public Vector3 pastVelocityDirection;
    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        //decelerationTime = pastVelocityDirection / deceleration;
        //transform.position = transform.position + currentVelocity;
    }
    void Update()
    {
        if (currentAcceleration>= maxSpeed)
        {
            currentAcceleration = maxSpeed;
        }
        PlayerMovenment();
        
        if (Input.GetKeyDown(KeyCode.B))    //spawn bomb at a random place near player
        {  //prevent the bomb spawning at player
            x = Random.Range(-2f, 2f);
            for (int i = 0; i < 10; i++)
            {
                y = Random.Range(-2f, 2f);
                if (x > -0.75 && x < 0.75 &&( y < -0.73 || y > 0.73))    //x is within player, y has to be upper or below
                {
                    break;
                }
                else if(!(x > -0.75 && x < 0.73))     // x is outside player position, any y works
                {
                    break;
                }
               
            }

            bombOffset = new Vector3(x,y, 0f);
            SpawnBombAtOffset(bombOffset);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //dash(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnBombTrail(Random.Range(0.7f, 2f), Random.Range(1, 10));
        }
        DetectAstroids(2, asteroidTransforms);
    }
    //This method allows player to move player
    void PlayerMovenment()
    {   //Easy way, set the velocity to 0, then everytime in if condition,
        //change the velocity to suitable one and multiply each by speed.
        
        currentVelocity = Vector3.zero;
        Vector3 accelerationDirection = Vector3.zero;
        
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            accelerationDirection += Vector3.left;
            pastVelocityDirection = Vector3.left;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            accelerationDirection += Vector3.right;
            pastVelocityDirection = Vector3.right;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerationDirection += Vector3.up;
            pastVelocityDirection = Vector3.up;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            accelerationDirection += Vector3.down;
            pastVelocityDirection = Vector3.down;
        }
        if(!Keyboard.current.downArrowKey.isPressed&&!Keyboard.current.upArrowKey.isPressed&&       //when player isn't pressing any keys
            !Keyboard.current.rightArrowKey.isPressed && !Keyboard.current.leftArrowKey.isPressed)
        {
            
            accelerationDirection += pastVelocityDirection;
            currentVelocity = accelerationDirection.normalized* Time.deltaTime;

        }
        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }
        
        //Accleration deirection is the direction that we are acceleration
        //we normalize it and then set the amount to acceleration by
        currentVelocity += accelerationDirection.normalized* currentAcceleration* Time.deltaTime;
        transform.position += accelerationDirection * Time.deltaTime;
        
         
        /*
        Vector3 temporary;
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            temporary=transform.position + velocity1;
            //if()//it is going out of bound
            transform.position = transform.position + velocity1;
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = transform.position + velocity2;
        }else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = transform.position + velocity3;
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = transform.position + velocity4;
        }
        */
    }
    void SpawnBombAtOffset(Vector3 offset)
    {
        DestroyBomb(); 
        bombInstantation =Instantiate(bombPrefab, transform.position+offset, Quaternion.identity);
        Debug.Log("X:" + offset.x + "Y:" +offset.y);
    }
    void DestroyBomb()
    {
        if (bombInstantation != null)
        {
            Destroy(bombInstantation);
        }
    } 

    //This function create a bomb trail behind player
    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)    
    {
        ClearBombs();
        GameObject bomb;
        Vector3 location = transform.position - new Vector3(0, inBombSpacing, 0);
        for (int i =0;i< inNumberOfBombs ; i++) //creating bomb trails
        {
            bomb=Instantiate(bombPrefab, location, Quaternion.identity);
            bombs.Add(bomb);
            location -= new Vector3(0, inBombSpacing, 0);
        }

    }
    //This function clears bomb in previous record
    public void ClearBombs()
    {
        if (bombs != null)  
        {
            for (int i = 0; i < bombs.Count; i++)
            {
                Destroy(bombs[i]);
            }
            bombs.Clear();
        }
    }
    public void SpawnBombOnRandomCOrner(float inDistance)
    {
        int num = Random.Range(1, 5);
        
        if (num == 1)       //spawn at upper left corner
        {
            if (IsUpperLeftCornerEmpty)
            {
                Instantiate(bombPrefab, transform.position+new Vector3(-inDistance, inDistance, 0), Quaternion.identity);
                IsUpperLeftCornerEmpty = false;
            }
        }else if (num == 2)//spawn at lower left corner
        {
            if (IsLowerLeftCornerEmpty)
            {
                Instantiate(bombPrefab, transform.position + new Vector3(-inDistance, -inDistance, 0), Quaternion.identity);
                IsLowerLeftCornerEmpty = false;
            }

        }
        else if (num == 3)//spawn at lower right corner
        {
            if (IsLowerRightCornerEmpty)
            {
                Instantiate(bombPrefab, transform.position + new Vector3(+inDistance, -inDistance, 0), Quaternion.identity);
                IsLowerRightCornerEmpty = false;
            }
        }
        else               //spawn at upper right corner
        {
            if (IsUpperRightCornerEmpty)
            {
                Instantiate(bombPrefab, transform.position + new Vector3(+inDistance, +inDistance, 0), Quaternion.identity);
                IsUpperRightCornerEmpty = false;
            }
        }
    }
    //This function detects if inAsteroids are near by, if so, lines will be drawn from player, to
    //the Asterpoid with a 2.5 in length
    public void DetectAstroids(float inMaxRange, List<Transform> inAsteroids)
    {
        Vector3 normalizedVector;
        float distanceBetinAsteroidsAndTransform = 0f ;
        for (int i = 0; i < inAsteroids.Count; i++)
        {
            distanceBetinAsteroidsAndTransform = Vector3.Distance(transform.position, inAsteroids[i].position);
            if (distanceBetinAsteroidsAndTransform < inMaxRange)
            {
                normalizedVector = VectorMath.GetNormalizedVector(inAsteroids[i].position-transform.position);
                normalizedVector = new Vector3(normalizedVector.x * 2.5f, normalizedVector.y * 2.5f, 0);
                Debug.DrawLine(transform.position, transform.position+ normalizedVector, Color.green);
            }
        }
    }
    void dash (Vector2 newlocation)
    {
        //Vector2 distance = new Vector2( enemy.positon.x- transform.positon.x, enemy.positon.y - transform.Yield);
        //Magnitude =Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);
        //Normalize = new Vector2(distance.x / magnitude.x, distance.y / magnitude.y);
        //transform.x=Normalize.x *0.2, Normalize.y * 0.2;
    }
    //rEfrence https://discussions.unity.com/t/check-if-e-key-is-pressed-in-c/657221
}
