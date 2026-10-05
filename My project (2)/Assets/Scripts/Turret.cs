using UnityEngine;

public class Turret : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform targetTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);

        Vector3 directionTarget = targetTransform.position - transform.position;

        bool shouldWeTurnRight = false;

        float dotProductOfRight = AngleWk5.VectorDot(directionTarget, transform.right);

        shouldWeTurnRight = dotProductOfRight > 0f;

        if (shouldWeTurnRight)
        {
            transform.eulerAngles -= Vector3.forward*rotationSpeed* Time.deltaTime;
        }
        else
        {
            transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }
        
        Debug.Log(shouldWeTurnRight);
    }
}
