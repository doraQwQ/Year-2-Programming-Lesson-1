using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class AngleTest : MonoBehaviour
{
    public float radius = 2;
    public List<float> angles;
    int index = 0;
    public float shiftDuration=3;
    float shiftProgress;
    public Vector3 circlePos=Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float fortyFiveDegrees = 45f;
        float ffDInRadians = fortyFiveDegrees * Mathf.Deg2Rad;
        float twoPiRadians = 2*Mathf.PI;
        float tprInDegrees = twoPiRadians * Mathf.Rad2Deg;

        float currentAngle = 90f;
        Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        if (angles.Count - 1 != 10)
        {
            for (int i = 0; i < 10; i++)
            {
                angles.Add((int)Random.Range(0f, 360f));
            }

        }
        angles.Sort();
    }

    // Update is called once per frame
    void Update()
    {
        shiftProgress += Time.deltaTime;
        DrawCircle();
    }
    //This function draws a line to the points, and changes when player press space or wait for seconds
    void DrawCircle()
    {
       
            if (Keyboard.current.spaceKey.wasPressedThisFrame || shiftProgress> shiftDuration)
            {
                
                if(index+1> angles.Count - 1)
                {
                    index = 0;
                    shiftProgress = 0;
                    Debug.Log(index);
                }
                else
                {
                    index += 1;
                    shiftProgress = 0;
                    Debug.Log(index);
                }
                
            }
        float currentAngle = angles[index];
        float currentAngleInRadians = currentAngle * Mathf.Deg2Rad;


        Vector3 point = new Vector3(Mathf.Cos(currentAngleInRadians) * radius,
            Mathf.Sin(currentAngleInRadians) * radius, 0);
        Debug.DrawLine(circlePos, point+circlePos, Color.white,0.1f);
        
        
        
    }
}
