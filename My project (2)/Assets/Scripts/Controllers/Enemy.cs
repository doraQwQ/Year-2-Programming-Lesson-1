using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Vector3 orgin;
    float num = 1f;
    float speed = 0.3f;
    Vector3 up, down, right, left;
    void Start()
    {
        orgin = transform.position;
        up = transform.position + Vector3.up;
        down = transform.position + Vector3.down;
        right = transform.position + Vector3.right;
        left = transform.position + Vector3.left;
    }
    private void Update()
    {
        EnemyMovenment();
    }
    void EnemyMovenment()
    {
        Vector3 tempLocation = transform.position;
        //Vector3 temp;

        if (num == 1)//Going up
        {
            if (transform.position != up)
            {
                tempLocation.y +=  speed* Time.deltaTime;
            }
            else
            {
                num = 1.5f;
            }
            
        }
        if (!(num % 1 == 0))//If not at orgin and at any middle position
        {
            tempLocation += (orgin - transform.position).normalized * Time.deltaTime * speed;
         
        }
        transform.position = tempLocation;
    }
}
