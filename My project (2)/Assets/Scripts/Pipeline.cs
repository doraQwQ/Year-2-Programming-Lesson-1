using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public List<Vector3> mouseLocation = new List<Vector3>();
    float timer = 0f;
    bool start = false;
    Vector3 one;
    Vector3 two;
    public LineRenderer line;
    float magnitude = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line.startWidth = 0.02f;
        line.endWidth = 0.02f;
        line.startColor = Color.white;
        line.endColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0)) //LEFT MOUSE KEY being held 
        {   
            timer += Time.deltaTime;
            //if (mouseLocation.Count > 2)
            //{
            //    one = Camera.main.ScreenToWorldPoint(mouseLocation[mouseLocation.Count - 1]);
            //    two = Camera.main.ScreenToWorldPoint(mouseLocation[mouseLocation.Count - 2]);
            //    for (int i = 0; i < mouseLocation.Count - 1; i++)
            //    {
            //        Debug.DrawLine(one, two);
            //    }
            //}
            
            if (timer > 0.1f)
            { 
                mouseLocation.Add(Input.mousePosition);

                if (start && mouseLocation.Count > 2)  //draw from old to new
                {
                    one = Camera.main.ScreenToWorldPoint(mouseLocation[mouseLocation.Count - 1]);
                    two = Camera.main.ScreenToWorldPoint(mouseLocation[mouseLocation.Count - 2]);
                    start = !start;
                    line.positionCount = mouseLocation.Count;
                    line.SetPosition(mouseLocation.Count - 2, one);
                    line.SetPosition(mouseLocation.Count - 1, two);
                    
             
                }
                else if (!start && mouseLocation.Count > 2)      //draw from new to old  
                {
                    one = Camera.main.ScreenToWorldPoint(mouseLocation[mouseLocation.Count - 1]);
                    two = Camera.main.ScreenToWorldPoint(mouseLocation[mouseLocation.Count - 2]);
                    line.positionCount = mouseLocation.Count;
                    line.SetPosition(mouseLocation.Count - 2, two);
                    line.SetPosition(mouseLocation.Count - 1, one);
                    
                    
                    start = !start;
                }

                timer = 0; 
            }
        }
        if (Input.GetMouseButtonUp(0)) //released
        {
            magnitude = 0;
            for (int i = 0; i < mouseLocation.Count - 1; i++)
            {
                magnitude += Vector3.Distance(mouseLocation[i], mouseLocation[i+1]);
            }
            Debug.Log("Magnitude = " + Mathf.Round(magnitude));
        }
        if (Input.GetMouseButtonDown(0))   //clicked
        {
            mouseLocation.Clear();
            timer = 0;
            line.positionCount = 0;
            mouseLocation.Add(Input.mousePosition);
        }
       
    }
}
