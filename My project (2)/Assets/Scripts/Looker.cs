using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class Looker : MonoBehaviour
{
    public List<GameObject> looker;
    int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LooksAtElements();
    }

    void LooksAtElements()
    {
       float angle = AngleWk5.VectorToAngle(looker[index].transform.position);
        
        transform.eulerAngles.z = angle;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (index + 1 > looker.Count - 1)
            {
                index = 0;
            }
            index += 1;
        }
        //Debug.Log();

        //Bonus 
        float prevShortestDis = 100000;
        float prevIndex;
        for(int i= 0; i< looker.Count - 1; i++)
        {
            float shortDis = Vector3.Distance(transform.position, looker[i].transform.position);
            if (shortDis < prevShortestDis)
            {
                prevShortestDis = shortDis;
                prevIndex = i;
            }
        }
        //Make the looker looks at the rectange which is the index. 
    }
}
