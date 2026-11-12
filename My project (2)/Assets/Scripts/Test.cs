using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 angles = new Vector2(-2, 0);
        Vector2 sizes = new Vector2(2, 2);
        RaycastHit2D check = BoxCast(transform.position, sizes, 0, Vector2.left, 3, 0, -Mathf.Infinity,Mathf.Infinity);
        
        if(check.collider != null)
        {
            print(check.collider.gameObject.name);
        }
        
    }
    //Playing around with box cast physic 2D
    public static RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth)
    {
        return Physics2D.BoxCast(origin, size, angle, direction, distance, layerMask, minDepth, maxDepth);

    }
}
