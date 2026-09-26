using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void AsteroidMovement()
    {
        float a = Random.Range(-5, 5);
        float b = Random.Range(-5, 5);
        Vector3 newLocation= new Vector3(a, b, 0);
        Vector3 Vector, realLocation ;
        Vector = newLocation.normalized* maxFloatDistance*Time.deltaTime;
        arrivalDistance = realLocation - transform.position;
        if (arrivalDistance < 5)
        {   //if close enough, find a new location to go to

        }
        transform.position += moveSpeed * Time.deltaTime;


    }
}
