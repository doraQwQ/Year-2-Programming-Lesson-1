using UnityEngine;
using UnityEngine.UIElements;



public class SquareSpawner : MonoBehaviour
{
    public Vector2 mousePosition;
    int length = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Draw a white square when click in game view
        
        mousePosition = Camera.main.WorldToScreenPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (mousePosition.x <= Screen.width && mousePosition.y <= Screen.height)//if it is in game view
                                                                                    //use center point 
                Debug.DrawLine(new Vector3(Input.mousePosition.x - length, Input.mousePosition.y + length, 0),
                    new Vector3(Input.mousePosition.x + length, Input.mousePosition.y + length, 0));//top line

                Debug.DrawLine(new Vector3(Input.mousePosition.x - length, Input.mousePosition.y + length, 0),
                    new Vector3(Input.mousePosition.x - length, Input.mousePosition.y - length, 0));//left line

                Debug.DrawLine(new Vector3(Input.mousePosition.x + length, Input.mousePosition.y - length, 0),
                    new Vector3(Input.mousePosition.x - length, Input.mousePosition.y - length, 0));//bottom line

                Debug.DrawLine(new Vector3(Input.mousePosition.x + length, Input.mousePosition.y + length, 0),
                    new Vector3(Input.mousePosition.x + length, Input.mousePosition.y - length, 0));//right line

        }



    }
    
}

