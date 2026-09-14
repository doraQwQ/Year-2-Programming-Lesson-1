using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Sprite bomb;
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public Vector2 spawnOffset;
    void Update()
    {

    }
    void SpawnBombAtOffset(Vector3 offset)
    {
        Instansate(bomb, offset.x, offset.y);
    }
    //rEfrence https://discussions.unity.com/t/check-if-e-key-is-pressed-in-c/657221
}
