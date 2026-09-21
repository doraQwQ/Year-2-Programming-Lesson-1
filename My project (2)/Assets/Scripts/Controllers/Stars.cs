using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        drawConsetellation();
    }
    void drawConsetellation()
    {
        //foreach (Transform whatever in starTransforms)
        //{
        //    Debug.Log(whatever.positon)
        //}
        //if using this one, need to create addition storing points, then use them to calculate and somehow
        //knowing at some point it is the end and stops the code????
           
        
        for (int i = 0; i < starTransforms.Count-1; i++)
        {
            int x = 10;
            Debug.DrawLine(starTransforms[i].position, starTransforms[i++].position);
        }
    }
}
