using UnityEngine;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float GetMagnitude(Vector2 vector)
    {

        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }
    void DrawSquare(Vector2 centerpoint, float size, Color color, float duration)
    {

    }
}
