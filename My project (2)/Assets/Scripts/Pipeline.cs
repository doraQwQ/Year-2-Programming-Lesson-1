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

        if (Input.GetMouseButtonDown(0))
        {   //being held
            mouseLocation.Add(Input.mousePosition);

        }
        if (Input.GetMouseButtonUp(0)) //clicked
        {
            timer = 0f;
            start = true;
        }
        if (start)
        {
            timer += Time.deltaTime;
        }
    }
}
