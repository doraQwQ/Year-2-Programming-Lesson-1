using UnityEngine;

public class Test : MonoBehaviour
{
    public Rigidbody2D yeah;
    
    public GameObject a;
    public GameObject b;
    float c =100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yeah = a.GetComponent<Rigidbody2D>();
      
        //yeah.angularVelocity = 360f;
        //yeah.angularDamping = 2f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 closestPoint = yeah.ClosestPoint(b.transform.position);

        Debug.DrawLine(b.transform.position, closestPoint, Color.red);
        /*
        Vector2 angles = new Vector2(-2, 0);
        Vector2 sizes = new Vector2(2, 2);
        RaycastHit2D check = BoxCast(transform.position, sizes, 0, Vector2.left, 3, 0, -Mathf.Infinity,Mathf.Infinity);
        
        if(check.collider != null)
        {
            print(check.collider.gameObject.name);
        }
        */

    }
    //Playing around with box cast physic 2D
    public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth)
    {
        return Physics2D.BoxCast(origin, size, angle, direction, distance, layerMask, minDepth, maxDepth);

    }
    
}
