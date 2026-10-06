using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 bombOffset;
    public Vector2 spawnOffset;
    public float x;
    public float y;
    public GameObject bombInstantation;
    GameObject bombInstansTwo;
    public List<GameObject> bombs = new List<GameObject>();

    bool IsUpperLeftCornerEmpty = true, IsLowerLeftCornerEmpty = true,
         IsLowerRightCornerEmpty = true, IsUpperRightCornerEmpty = true;

    public Vector3 currentVelocity = Vector3.right;
    
    float locationX;//for player bomb shield
    float locationY;
    float angle;

    //public Vector3 velocity1 = Vector3.up;
    //public Vector3 velocity2 = Vector3.left;
    //public Vector3 velocity3 = Vector3.down;
    //public Vector3 velocity4 = Vector3.right;

    public float speed=2;
    public float accelerationTime=3f;
    public float currentAcceleration;
    public float maxSpeed;
    public float deceleration=0.9f;
    public float decelerationTime=1.5f;
    public Vector3 pastVelocityDirection;
    public Vector3 pastVelocity;
    public float RadiusSize;
    public List<Vector3> points=new List<Vector3> { Vector3.zero, Vector3.up , Vector3.down};

    public List<Vector3> anglesInRad;
    public List<int> numbers;
    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        //deceleration = speed / decelerationTime;
        deceleration = maxSpeed / decelerationTime;
        //transform.position = transform.position + currentVelocity;
    }
    void Update()
    {
        EnemyRadar(3, 6);
        //DrawGreenHexigonAroundPlayer(2, 2);
        angle += 1 * Time.deltaTime;
        PlayerBombShield();

        if (currentAcceleration>= maxSpeed)
        {
            currentAcceleration = maxSpeed;
        }
        PlayerMovenment();
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            RandomTeleportWithinDistance(2);
        }
        /*
        if (Input.GetKeyDown(KeyCode.B))    //spawn bomb at a random place near player
        {  //this code ensures that the bomb is not spawning at player
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
        */
    }
    //This function takes in num of points, which decide the green hexagon sides, and shields player
    //then when enemy enters it turn red 
    void DrawGreenHexigonAroundPlayer(float radius,int points)
    {
        List<Vector3> RadiusPointList= new List<Vector3>();
        for (int i = 0; i < points - 1; i++)
        {
            float a = Random.Range(0,360);
            float angInRad = a * Mathf.Deg2Rad;
            Vector3 newPoint = new Vector3(Mathf.Cos(angInRad) * radius, Mathf.Sin(angInRad) * radius, 0);
            RadiusPointList.Add(newPoint);
        }
        for (int t = 0; t < RadiusPointList.Count - 2; t++)
        {
            Debug.DrawLine(RadiusPointList[t]+ transform.position, RadiusPointList[t+1]+ transform.position, Color.green, 3f);
        }
       
    }
    public void EnemyRadar(float radius, int circlePoints)
    {
        anglesInRad.Clear();
        float times = 360 / circlePoints;
        for(int i = 1 ; i <= circlePoints; i++) //Generate points,convert to rad, calculate location, store in list
        {
            float angleInRad = times * i * Mathf.Deg2Rad;
            Vector3 shieldLocation = new Vector3(Mathf.Cos(angleInRad) * radius, Mathf.Sin(angleInRad) * radius, 0);
            anglesInRad.Add(shieldLocation+ transform.position);
        }
        if (Vector3.Distance(transform.position, enemyTransform.position) <= radius)  //enemies inside
        {
            for(int a = 0; a <= circlePoints-1; a++)
            {
                if (a == circlePoints)  //Connecting last to first
                {
                    Debug.DrawLine(anglesInRad[circlePoints-1], anglesInRad[0], Color.red);
                }
                else
                {
                    Debug.DrawLine(anglesInRad[a], anglesInRad[a + 1], Color.red);
                }
               
            }
        }else
        {
            for (int b = 0; b <= circlePoints-1; b++)
            {
                Debug.DrawLine(anglesInRad[b], anglesInRad[b + 1], Color.green);
            }
        }

    }
    void RandomTeleportWithinDistance(float radius)
    {
        float degree = Random.Range(0f, 360f);
        float degToRad = degree*Mathf.Deg2Rad;
        
        Vector3 newLocation = new Vector3( Mathf.Cos(degToRad) * radius, Mathf.Sin(degToRad) * radius, 0);
        transform.position = newLocation+transform.position;
    }
    //This method allows player to move player
    void PlayerMovenment()
    {   //Easy way, set the velocity to 0, then everytime in if condition,
        //change the velocity to the right direction one and multiply each by speed.
        Vector3 accelerationDirection = Vector3.zero;
        if (Keyboard.current.leftArrowKey.isPressed)
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
        //Accleration direction is the direction that we are acceleration
        //we normalize it and then set the amount to acceleration by
      
        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;
        if (!(currentVelocity.magnitude == 0))
        {
            pastVelocity = currentVelocity;
        }
        if (currentAcceleration > 0)
        {
            deceleration = currentAcceleration;
        }

        if (!(Keyboard.current.downArrowKey.isPressed || Keyboard.current.upArrowKey.isPressed ||  //deceleration
            Keyboard.current.rightArrowKey.isPressed || Keyboard.current.leftArrowKey.isPressed))
        { 
            currentVelocity -= pastVelocity * deceleration* Time.deltaTime;
        }
        /*
        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }*/
        transform.position += currentVelocity * Time.deltaTime;




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
    //This function create a bomb that circles around the player and protects the player from enemy.
    void PlayerBombShield()
    {
        Vector3 location = transform.position;
        locationX=location.x+ Mathf.Cos(angle)*1.5f;
        locationY=location.y + Mathf.Sin(angle)*1.5f ;
        if (bombInstansTwo == null)
        {
            bombInstansTwo = Instantiate(bombPrefab, new Vector3(locationX, locationY, 0), Quaternion.identity);

        }else 
        {
            bombInstansTwo.transform.position = new Vector3(locationX, locationY, 0);
        }
       
    }

    /*
     * //HomeWork
    void SpawnBombAtOffset(Vector3 offset)
    {
        DestroyBomb(); 
        bombInstantation =Instantiate(bombPrefab, transform.position+offset, Quaternion.identity);
        Debug.Log("X:" + offset.x + "Y:" +offset.y);
    }
    //HomeWork
    void DestroyBomb()
    {
        if (bombInstantation != null)
        {
            Destroy(bombInstantation);
        }
    } 
    //HomeWork
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
    //HomeWork
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
    //HomeWork
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
    //HomeWork
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
    //HomeWork
    void dash (Vector2 newlocation)
    {
        //Vector2 distance = new Vector2( enemy.positon.x- transform.positon.x, enemy.positon.y - transform.Yield);
        //Magnitude =Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);
        //Normalize = new Vector2(distance.x / magnitude.x, distance.y / magnitude.y);
        //transform.x=Normalize.x *0.2, Normalize.y * 0.2;
    }
    //rEfrence https://discussions.unity.com/t/check-if-e-key-is-pressed-in-c/657221
    */
}
