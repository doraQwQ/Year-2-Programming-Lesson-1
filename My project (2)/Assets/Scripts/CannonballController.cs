using Unity.VisualScripting;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    GunshipController gun;
    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        //After lifespan seconds, this object will be destroyed
        Destroy(gameObject, lifespan);
    }
    void OnCollisionEnter2D(Collision2D CrackBoom)
    {
        
        if(CrackBoom.gameObject.GetComponent<CannonballController>()!=null)
        {
            Destroy(CrackBoom.gameObject);
            Destroy(gameObject);
        }

    }
    

}
