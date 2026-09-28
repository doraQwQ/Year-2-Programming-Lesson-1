using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    Vector3 drawing;
    float progress;
    int i = 0;
    // Update is called once per frame
    void Update()
    {
        progress +=Time.deltaTime/0.5f;

        drawConsetellation();
    }
    void drawConsetellation()
    {
        //foreach (Transform whatever in starTransforms)
        //{
        //    Debug.Log(whatever.positon)
        //}
        //if using this one, need to create addition storing points, then use them to calculate and somehow
        //knowing at some point it is the end and stops the code?

        //making new position
        drawing = Vector3.Lerp(starTransforms[i].position, starTransforms[i+1].position, progress);
        if (progress > 1f)
        {
            progress = 0;
            if ((i + 1) <= starTransforms.Count - 2)   //prevent number be greater than starTransform.Count
            {
                i += 1;     
            }
            else  //num=max
            {
                i = 0;
            }
            
           
        }
        
        Debug.DrawLine(starTransforms[i].position, drawing, Color.white);
    }
}
