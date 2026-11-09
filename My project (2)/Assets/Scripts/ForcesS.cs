using UnityEngine;
using UnityEngine.InputSystem;
public class ForcesS : MonoBehaviour
{
    public Rigidbody2D rB;
    public float forceStrength = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }
    public enum ProjectileType { 
        names,Lilia,Zoya
    }
    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldMousePosition.z = 0;
            Vector3 directionToApplyforce = worldMousePosition - transform.position;
            rB.AddForce(directionToApplyforce.normalized * forceStrength, ForceMode2D.Force);
        }
        
    }
    void OnCollisionEnter2D(Collision2D CrackBoom)
    {

    }
    void OnCollusionStay2D(Collision2D KaLaBoom)
    {

    }
    void OnCollisionStay2D(Collision2D SiuBoom)
    {

    }

    private void OnCollisionEnter2D(Collider2D CrackBoom)
    {

    }
    private void OnCollusionStay2D(Collider2D KaLaBoom)
    {

    }
    private void OnCollisionStay2D(Collider2D SiuBoom)
    {

    }

}
