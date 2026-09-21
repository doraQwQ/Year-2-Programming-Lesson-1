using UnityEngine;
using System.Collections.Generic;
//This is a class which is mostly about list
public class Zoo : MonoBehaviour
{
    public List<string> animals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animals.Add("Dinosaur");
        animals.Add("Tiger");
        animals.Add("Penguin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
