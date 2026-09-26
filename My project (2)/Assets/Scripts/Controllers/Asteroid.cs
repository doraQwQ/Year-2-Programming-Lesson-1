using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector3 Vector, newLocation;

    // Start is called before the first frame update
    void Start()
    {
        arrivalDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
    public void AsteroidMovement()
    {
        if (arrivalDistance < 5)
        {   //if close enough, find a new location to go to
            float a = Random.Range(-10, 10);
            float b = Random.Range(-10, 10);
            newLocation = new Vector3(a, b, 0);
            arrivalDistance = 10;
        }

        Vector = newLocation.normalized* maxFloatDistance*Time.deltaTime;
        arrivalDistance = (newLocation - transform.position).magnitude;
        transform.position += Vector * Time.deltaTime;


    }
}
