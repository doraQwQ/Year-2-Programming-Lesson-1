using UnityEngine;
using System.Collections.Generic;

public class BlackHole : MonoBehaviour
{
    public float distBetweenObject = 3;
    public GameObject blackHole;
    public GameObject enemy;
    public GameObject player;
    public GameObject star;
    public List<GameObject> stars;
    public GameObject asteroids;
    public float rotationSpeed = 60f;
    float movingSpeed=30f;
    float shortenAmount=0.15f;
    float destoryDis = 0.01f;
    List<GameObject> thingsTooClose = new List<GameObject>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectDistance();
    }
    void DetectDistance()
    {   
        //Initalize the value so the variable exist, but will change later
        float distWithStar = distBetweenObject+1;
        thingsTooClose.Clear();
        if (enemy.transform == null)        //in case there is no enemy
        { 
            return;
        }
        float distWithEnemy = Vector3.Distance(blackHole.transform.position, enemy.transform.position);
        float distWithPlayer = Vector3.Distance(blackHole.transform.position, player.transform.position);
        for(int ii = 0; ii < stars.Count - 1; ii++)
        {
            distWithStar = Vector3.Distance(blackHole.transform.position, stars[ii].transform.position);
            if (distWithStar < distBetweenObject)
            {
                thingsTooClose.Add(stars[ii]);
            }
            if (distWithStar <= destoryDis)
            {
                Destroy(star);
                gameObject.SetActive(false);
            }
        }
        distWithStar = Vector3.Distance(blackHole.transform.position, star.transform.position);
        float distWithAsteroids = Vector3.Distance(blackHole.transform.position, asteroids.transform.position);

        //If the things are too close to blackhole, destroy them
        if (distWithEnemy <= destoryDis)
        {
            Destroy(enemy);
            gameObject.SetActive(false);
        }
        if(distWithPlayer<= destoryDis)
        {
            Destroy(player);
            gameObject.SetActive(false);
        }
        
        if(distWithAsteroids<= destoryDis)
        {
            Destroy(asteroids);
            gameObject.SetActive(false);
        }

        //If the things are within blackhole distance and not at center of blackhole
        if (distWithEnemy < distBetweenObject)
        {
            thingsTooClose.Add(enemy);          
        }
        if(distWithPlayer < distBetweenObject)
        {
            thingsTooClose.Add(player);
        }     
        if(distWithAsteroids < distBetweenObject)
        {
            thingsTooClose.Add(asteroids);
        }

        
        if (thingsTooClose != null)  //Suck in item.
        {
            
            for (int i = 0; i < thingsTooClose.Count; i++)

            {
                Transform tempVector = thingsTooClose[i].transform;

                //Changing the rotation of the sucked in object
                Vector3 newRotation = tempVector.eulerAngles - Vector3.forward * rotationSpeed * Time.deltaTime;

                //Assigning it
                tempVector.eulerAngles = newRotation;            
                
                //--------------------------------------------

                //Changing position part

                //use the resultant vector
                Vector3 DistWithBlackHole = tempVector.position - transform.position;

                print("initial position: " + tempVector.position);

                //Gets the current vector angle relative to blackhole
                float tempAngle = Mathf.Atan2(DistWithBlackHole.y, DistWithBlackHole.x)* Mathf.Rad2Deg;

                //Gets the radius and shrunk it
                float currentRadius = DistWithBlackHole.magnitude - shortenAmount * Time.deltaTime;
                
                //Changing the position to be more clockwise
                tempAngle -= movingSpeed * Time.deltaTime;
                tempAngle *= Mathf.Deg2Rad; //To radians

                Vector3 newPos = new Vector3(Mathf.Cos(tempAngle) * currentRadius, Mathf.Sin(tempAngle) * currentRadius, DistWithBlackHole.z);
                //Vector3 newPos = new Vector3(Mathf.Cos(tempAngle), Mathf.Sin(tempAngle), 0);
                thingsTooClose[i].transform.position = newPos+transform.position;
                
                
            }
            
        }
    }
}
