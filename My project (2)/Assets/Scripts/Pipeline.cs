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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {   //being held
            
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                line.positionCount = mouseLocation.Count;
                mouseLocation.Add(Input.mousePosition);

                Debug.Log("WAAAAA");
                if (start&&mouseLocation.Count>2)  //draw from old to new
                { 
                    one = Camera.main.ScreenToWorldPoint(mouseLocation[mouseLocation.Count - 1]);
                    start = !start;
                    Debug.Log("WBBB");
                    for(int i = 0; i < mouseLocation.Count - 1; i++)
                    {
                        line.SetPosition(mouseLocation.Count - 1, one);
                    }
                }
                else  if(!start&& mouseLocation.Count > 2)      //draw from new to old  
                {
                    one = Camera.main.ScreenToWorldPoint(mouseLocation[mouseLocation.Count - 1]);
                    for (int i = 0; i < mouseLocation.Count - 1; i++)
                    {
                        line.SetPosition(mouseLocation.Count - 1, one);
                    }
                    start = !start;
                    
                }
                timer = 0; ;
            }
        }
        if (Input.GetMouseButtonUp(0)) //clicked
        {
            mouseLocation.Clear();    
            timer = 0;
            mouseLocation.Add(Input.mousePosition);
            Debug.Log(mouseLocation[mouseLocation.Count - 1]);
        }
       
    }
}
