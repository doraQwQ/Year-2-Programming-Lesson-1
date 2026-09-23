using NUnit.Framework;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public List <Vector3> mouseLocation;
    float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            mouseLocation.Add(Input.mousePosition);
        }
    }
}
