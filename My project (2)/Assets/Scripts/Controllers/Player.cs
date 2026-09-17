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
    public float x;
    public float y;
    public GameObject bombInstantation;
    public List<GameObject> bombs = new List<GameObject>();
    bool IsUpperLeftCornerEmpty = true, IsLowerLeftCornerEmpty = true,
         IsLowerRightCornerEmpty = true, IsUpperRightCornerEmpty = true;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))    //spawn bomb at a random place near player
        {  //prevent the bomb spawning at player
            x = Random.Range(-2f, 2f);
            for (int i = 0; i < 10; i++)
            {
                y = Random.Range(-2f, 2f);
                if (x > -0.75 && x < 0.75 &&( y < -0.73 || y > 0.73))    //x is within player, y has to be upper or below
                {
                    break;
                }
                else if(!(x > -0.75 && x < 0.73))     // x is outside player position, any y works
                {
                    break;
                }
               
            }

            bombOffset = new Vector3(x,y, 0f);
            SpawnBombAtOffset(bombOffset);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //dash(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnBombTrail(Random.Range(0.7f, 2f), Random.Range(1, 10));
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

    //This function create a bomb trail behind player
    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)    
    {
        ClearBombs();
        GameObject bomb;
        Vector3 location = transform.position - new Vector3(0, inBombSpacing, 0);
        for (int i =0;i< inNumberOfBombs ; i++) //creating bomb trails
        {
            bomb=Instantiate(bombPrefab, location, Quaternion.identity);
            bombs.Add(bomb);
            location -= new Vector3(0, inBombSpacing, 0);
        }

    }
    //This function clears bomb in previous record
    public void ClearBombs()
    {
        if (bombs != null)  
        {
            for (int i = 0; i < bombs.Count; i++)
            {
                Destroy(bombs[i]);
            }
            bombs.Clear();
        }
    }
    public void SpawnBombOnRandomCOrner(float inDistance)
    {
        int num = Random.Range(1, 5);
        
        if (num == 1)       //spawn at upper left corner
        {
            if (IsUpperLeftCornerEmpty)
            {
                Instantiate(bombPrefab, transform.position+new Vector3(-inDistance, inDistance, 0), Quaternion.identity);
                IsUpperLeftCornerEmpty = false;
            }
        }else if (num == 2)//spawn at lower left corner
        {
            if (IsLowerLeftCornerEmpty)
            {
                Instantiate(bombPrefab, transform.position + new Vector3(-inDistance, -inDistance, 0), Quaternion.identity);
                IsLowerLeftCornerEmpty = false;
            }

        }
        else if (num == 3)//spawn at lower right corner
        {
            if (IsLowerRightCornerEmpty)
            {
                Instantiate(bombPrefab, transform.position + new Vector3(+inDistance, -inDistance, 0), Quaternion.identity);
                IsLowerRightCornerEmpty = false;
            }
        }
        else               //spawn at upper right corner
        {
            if (IsUpperRightCornerEmpty)
            {
                Instantiate(bombPrefab, transform.position + new Vector3(+inDistance, +inDistance, 0), Quaternion.identity);
                IsUpperRightCornerEmpty = false;
            }
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
