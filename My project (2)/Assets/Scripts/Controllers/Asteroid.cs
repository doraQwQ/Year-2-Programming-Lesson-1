using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed=4;
    public float arrivalDistance;
    public float maxFloatDistance;

    Vector3 newLocation = Vector3.zero;
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
        Vector3 Vector;
        if (arrivalDistance < 3)
        {   //if close enough, find a new location to go to
            float a = Random.Range(-10, 10);
            float b = Random.Range(-10, 10);
            newLocation = new Vector3(a, b, 0);
            arrivalDistance = 5;
        }

        Vector = (newLocation-transform.position).normalized* maxFloatDistance;
        arrivalDistance = (newLocation - transform.position).magnitude;
        transform.position += Vector * Time.deltaTime;


    }
}
