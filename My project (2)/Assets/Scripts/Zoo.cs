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
        animals.Add("Peacok");
        animals.Remove("Dinosaur");

        foreach(string currentAnimal in animals)//the string is tempoary
        {
            Debug.Log("Our next animal is " + currentAnimal);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
