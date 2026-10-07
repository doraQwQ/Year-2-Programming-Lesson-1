using UnityEngine;

public class Moon : MonoBehaviour
{
    public GameObject moonPrefab;
    public Transform spawnMoon;
    float angle = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(2, 50, spawnMoon);
    }
    public void OrbitalMotion(float radius,float speed, Transform target)
    {
        float angleToInc = 360 / speed;
        
        float angleInRad = angle * Mathf.Deg2Rad;
        Vector3 newPoint= new Vector3(Mathf.Cos(angleInRad)*radius,Mathf.Sin(angleInRad)*radius,0);
        if (spawnMoon == null)  //if there is nothing, spawn a moon
        {
           GameObject newMoon = Instantiate(moonPrefab, newPoint + target.position, Quaternion.identity);
           spawnMoon = newMoon.transform;
        }

        spawnMoon.transform.position = newPoint + target.position;
        angle += angleToInc * Time.deltaTime;
        

        Debug.Log(spawnMoon != null);
        Debug.Log(newPoint);
    }
}
