using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Enemy enemy= GetComponent<Enemy>;
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 bombOffset;
    public Vector2 spawnOffset;

    public GameObject bombInstantation;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))    //spawn bomb at a random place near player
        {  //prevent the bomb spawning at player

            
            bombOffset = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0f);
            SpawnBombAtOffset(bombOffset);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //dash(transform.position);

        }
    }
    void SpawnBombAtOffset(Vector3 offset)
    {
        DestroyBomb();
        bombInstantation =Instantiate(bombPrefab, transform.position+offset, Quaternion.identity);
        Debug.Log("X:" + offset.x + "Y:" +offset.y);
    }
    void DestroyBomb()
    {
        if (bombInstantation != null)
        {
            Destroy(bombInstantation);
        }
    } 
    void dash (Vector2 newlocation)
    {
        //Vector2 distance = new Vector2( enemy.positon.x- transform.positon.x, enemy.positon.y - transform.Yield);
        //Magnitude =Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);
        //Normalize = new Vector2(distance.x / magnitude.x, distance.y / magnitude.y);
        //transform.x=Normalize.x *0.2, Normalize.y * 0.2;
    }
    //rEfrence https://discussions.unity.com/t/check-if-e-key-is-pressed-in-c/657221
}
