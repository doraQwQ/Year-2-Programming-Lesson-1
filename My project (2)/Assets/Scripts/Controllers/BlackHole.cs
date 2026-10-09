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

    }
}
