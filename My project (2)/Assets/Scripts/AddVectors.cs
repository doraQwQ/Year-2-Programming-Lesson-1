using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

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
      if(Input.GetKeyDown (KeyCode.B))
        {
            Debug.DrawLine(Vector2.zero, bTransform.position, UnityEngine.Color.blue);
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
