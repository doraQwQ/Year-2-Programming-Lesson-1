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
        
       float angle = AngleWk5.VectorToAngle(looker[index].transform.position - transform.position);
       
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,angle);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            index += 1;
            if (index  > looker.Count-1)
            {
                index = 0;
            }
            
        }
        //Debug.Log();

        //Bonus 
        //Looker should look at the closest object in list
        float prevShortestDis = 100000;
        int prevIndex;
        for(int i= 0; i< looker.Count - 1; i++)
        {
            float shortDis = Vector3.Distance(transform.position, looker[i].transform.position);
            if (shortDis < prevShortestDis)
            {
                prevShortestDis = shortDis;
                prevIndex = i;
            }
        }
        //Make the looker looks at the rectangle which is the index. 
        angle = AngleWk5.VectorToAngle(looker[prevIndex].transform.position - transform.position);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);

    }
}
