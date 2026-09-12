using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
//Dora Cheng 2026-9-12
public class AddVectors : MonoBehaviour
{
    public Transform rTransform;
    public Transform bTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputValues();
        transform.position = rTransform.position;
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
    void InputValues()
    {
        if (GetComponent<SpriteRenderer>().color ==  UnityEngine.Color.red )
        {
            transform.position = rTransform.position;
        }else if (GetComponent<SpriteRenderer>().color == UnityEngine.Color.blue)
            {
                transform.position = bTransform.position;
            }
    }
}
