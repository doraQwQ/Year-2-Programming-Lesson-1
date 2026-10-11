using UnityEngine;
using System.Collections.Generic;

public class BlackHole : MonoBehaviour
{
    public float distBetweenObject = 3;
    public GameObject blackHole;
    public GameObject enemy;
    public GameObject player;
    public GameObject star;
    public GameObject asteroids;
    public float rotationSpeed = 60;
    float radiusToSuckIn = 5;
    float movingSpeed=0.5;
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
        thingsTooClose.Clear();
        if (enemy.transform == null)        //in case there is no enemy
        { 
            return;
        }
        float distWithEnemy = Vector3.Distance(blackHole.transform.position, enemy.transform.position);
        float distWithPlayer = Vector3.Distance(blackHole.transform.position, player.transform.position);
        float distWithStar = Vector3.Distance(blackHole.transform.position, star.transform.position);
        float distWithAsteroids = Vector3.Distance(blackHole.transform.position, asteroids.transform.position);
        
        if (distWithEnemy < distBetweenObject)
        {
            thingsTooClose.Add(enemy);
        }
        if(distWithPlayer < distBetweenObject)
        {
            thingsTooClose.Add(player);
        }
        if(distWithStar < distBetweenObject)
        {
            thingsTooClose.Add(star);
        }
        if(distWithAsteroids < distBetweenObject)
        {
            thingsTooClose.Add(asteroids);
        }

        
        if (thingsTooClose != null)  //Suck in item.
        {
            for (int i = 0; i < thingsTooClose.Count; i++)
            {
                Vector3 newRotation = thingsTooClose[i].transform.eulerAngles + Vector3.forward * rotationSpeed*Time.deltaTime;
                thingsTooClose[i].transform.eulerAngles = newRotation;
                Vector3 DistWithBlackHole = newRotation.position - transform.position;
                float tempAngle = Mathf.Atan2.DistWithBlackHole(DistWithBlackHole.y, DistWithBlackHole.x);
                float newPos = thingsTooClose[i].transform
            }
            //Using math formula to find the angle
            //Using the angle to 
        }
    }
}
