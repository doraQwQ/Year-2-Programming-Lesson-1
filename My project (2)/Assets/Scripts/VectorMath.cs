using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
    public float GetMagnitude(Vector2 vector)
    {

        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }
    public static void DrawSquare(Vector2 centerpoint, float size, Color color, float duration)
    {
        Vector2 startPoint = centerpoint + new Vector2(-size, size);    //Above line
        Vector2 endpoint = centerpoint + new Vector2(size, size);
        Debug.DrawLine(startPoint, endpoint, color, duration);

         startPoint = centerpoint + new Vector2(-size, size);    //left line
         endpoint = centerpoint + new Vector2(-size, -size);
        Debug.DrawLine(startPoint, endpoint, color, duration);

        startPoint = centerpoint + new Vector2(-size, -size);    //bottom line
        endpoint = centerpoint + new Vector2(size, -size);
        Debug.DrawLine(startPoint, endpoint, color, duration);

        startPoint = centerpoint + new Vector2(size, size);    //right line
        endpoint = centerpoint + new Vector2(size, -size);
        Debug.DrawLine(startPoint, endpoint, color, duration);
        
    }
}
