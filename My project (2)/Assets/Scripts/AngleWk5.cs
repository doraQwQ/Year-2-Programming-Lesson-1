using UnityEngine;

public class AngleWk5 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*float firstAngle = 45f;
        float secondAngle = 225f;

        float firstVectorX = Mathf.Cos(45f * Mathf.Deg2Rad);
        float secondVectorX = Mathf.Cos(225f * Mathf.Deg2Rad);

        Debug.Log(firstVectorX);
        Debug.Log(secondVectorX);
         * */
        Mathf.Atan2(0.7f, -0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Converrt from a vector to an angle based around x-axis
    public static float VectorToAngle(Vector3 Vvector)
    {
        float angle = Mathf.Atan2(Vvector.y, Vvector.x)* Mathf.Rad2Deg;
        return angle-90f;
    }
}
