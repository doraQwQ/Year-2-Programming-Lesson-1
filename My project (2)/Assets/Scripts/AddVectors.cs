using UnityEngine;

public class AddVectors : MonoBehaviour
{
    Transform rtransform;
    Transform bTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer R= GetComponent<SpriteRenderer>(); ;
        SpriteRenderer B= GetComponent<SpriteRenderer>(); ;
        R.color = Color.red;
        B.color = Color.blue;

    }

    // Update is called once per frame
    void Update()
    {
      
        //Vector2 rPlusB = 
    }
}
