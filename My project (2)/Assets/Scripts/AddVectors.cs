using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
//Dora Cheng 
public class AddVectors : MonoBehaviour
{
    public Transform rTransform;
    public Transform bTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 rPlusB= rTransform.position + bTransform.position;
      if(Input.GetKeyDown (KeyCode.B))      //question 2
        {
            Debug.DrawLine(Vector2.zero, bTransform.position, UnityEngine.Color.blue);
        }
      if (Input.GetKeyDown(KeyCode.R))      //question 3
      {
          Debug.DrawLine(Vector2.zero, rTransform.position, UnityEngine.Color.red);
      }
      if( Input.GetKeyDown(KeyCode.R)&& Input.GetKeyDown(KeyCode.B))    //question 4
        {
            Debug.DrawLine(Vector2.zero, rPlusB, UnityEngine.Color.magenta);
        }
    }
   
}
