using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed=0.5f;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector3 location ;
    Vector3 newLocation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        arrivalDistance = 0;
        location = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
    public void AsteroidMovement()
    {
        Vector3 Vector;
        if (arrivalDistance < 1)
        {   //if close enough, find a new location to go to
            
            float a = Random.Range(location.x-3,location.x + 3);
            float b = Random.Range(location.x - 3, location.y + 3);

            newLocation = new Vector3(a, b, 0);
            arrivalDistance = 2;
        }

        Vector = (newLocation-transform.position).normalized* maxFloatDistance;
        arrivalDistance = (newLocation - transform.position).magnitude;
        transform.position += Vector * Time.deltaTime;


    }
}
