using UnityEngine;

public class Moon : MonoBehaviour
{
    public GameObject objects;
    public Transform star;
    float angle = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(2, 50, star);
    }
    public void OrbitalMotion(float radius,float speed, Transform target)
    {
        float angleToInc = 360 / speed;
        
        float angleInRad = angle * Mathf.Deg2Rad;
        Vector3 newPoint= new Vector3(Mathf.Cos(angleInRad)*radius,Mathf.Sin(angleInRad)*radius,0);
        if (objects == null)
        {
            objects = Instantiate(objects, newPoint + target.position, Quaternion.identity);
        }
       
        objects.transform.position = newPoint + target.position;
        angle += angleToInc * Time.deltaTime;
        

        Debug.Log(objects != null);
        Debug.Log(newPoint);
    }
}
