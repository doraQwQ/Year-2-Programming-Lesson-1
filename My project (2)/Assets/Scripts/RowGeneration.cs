using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RowGeneration : MonoBehaviour
{
    public TMP_InputField inputField;
    int x = Screen.width/3;
    int y = Screen.height/3;
    int value_inRow = 100;
    bool isValid = false;
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

                isValid = false;
                break;
            }
            if (!char.IsLetterOrDigit(answer[i]))
            {
                inputField.text = "Answer contains inappropriate values. Please enter again.";
                isValid = false;
                break;
            }
            if (i == answer.Length - 1)
            {
                isValid = true;
            }
                   
        }
        if (isValid)
        {
            int answerInInt = int.Parse(answer);
            for (int ii = 0; ii < answerInInt; ii++)
            {
                Debug.DrawLine(new Vector3(x, y - 100, 0),
                        new Vector3(x, y, 0));//top line

                Debug.DrawLine(new Vector3(x - 100, y, 0),
                    new Vector3(x - 100, y - 100, 0));//left line

                Debug.DrawLine(new Vector3(x + 100, y - 100, 0),
                    new Vector3(x - 100, y - 100, 0));//bottom line

                Debug.DrawLine(new Vector3(x + 100, y + 100, 0),
                    new Vector3(x + 100, y - 100, 0));//right line
                x += value_inRow;
                y += value_inRow;
            }
        }
        
    }
}
