using UnityEngine;

public class AngleCompairson : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 facingDirection = transform.up;
        float facing = AngleWk5.VectorToAngle(facingDirection);
        Debug.Log(facing);
        Debug.Log(transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
