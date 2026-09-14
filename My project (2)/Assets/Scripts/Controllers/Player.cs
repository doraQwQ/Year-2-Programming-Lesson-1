using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Enemy enemy= GetComponent<Enemy>;
    Sprite bomb;
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public Vector2 spawnOffset;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            dash(transform.position);

        }
    }
    void SpawnBombAtOffset(Vector3 offset)
    {
        //instantiate(bomb, offset.x, offset.y);
    }
    void dash (Vector2 newlocation)
    {
        Vector2 distance = new Vector2( enemy.positon.x- transform.positon.x, enemy.positon.y - transform.Yield);
        Magnitude =Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);
        Normalize = new Vector2(distance.x / magnitude.x, distance.y / magnitude.y);
        transform.x=Normalize.x *0.2, Normalize.y * 0.2;s
    }
    //rEfrence https://discussions.unity.com/t/check-if-e-key-is-pressed-in-c/657221
}
