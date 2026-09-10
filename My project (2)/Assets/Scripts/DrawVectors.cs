using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dVector= new Vector2 (0, 1);
        Vector2 eVector = new Vector2(3, -2);
        Debug.DrawLine(new Vector2(0, 0), dVector, Color.yellow);
        Debug.DrawLine(new Vector2(0,0),eVector,Color.grey);
    }
}
