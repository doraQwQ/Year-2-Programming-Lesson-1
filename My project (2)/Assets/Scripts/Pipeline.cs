using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public List<Vector3> mouseLocation = new List<Vector3>();
    float timer = 0f;
    bool start = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)&&timer>10f)
        {   //being held
            timer -= 10;            
            timer += Time.deltaTime;    
            mouseLocation.Add(Input.mousePosition); 
            
            if (start)  //draw from old to new
            {
                Debug.DrawLine(mouseLocation.Count - 2, mouseLocation.Count - 1);
                start = !start;
            }
            else        //draw from new to old  
            {
                Debug.DrawLine(mouseLocation.Count - 1, mouseLocation.Count - 2);
                start = !start;
            }
        }
        if (Input.GetMouseButtonUp(0)) //clicked
        {
            mouseLocation.Clear;    
            timer = 0;
            mouseLocation.Add(Input.mousePosition);
        }
       
    }
}
