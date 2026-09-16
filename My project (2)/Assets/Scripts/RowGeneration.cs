using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RowGeneration : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void generateSquares()
    {
        string answer = inputField.text;
        for(int i=0;  i<answer.Length-1; i++)       //if the answer have alphabets,ignore upper and lower case
        {
            if (char.IsLetter(answer[i]))
            {
                inputField.text = "Answer contains letters. Please enter again.";
            }
            if (char.IsLetterOrDigit(answer[i]))
            {
                inputField.text = "Answer contains inappropriate values. Please enter again.";
            }
        }



    }
}
