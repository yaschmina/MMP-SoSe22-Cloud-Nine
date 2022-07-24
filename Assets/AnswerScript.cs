using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    //public GameObject button;


    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            //GetComponent<Image>().color = Color.green;
            quizManager.correct();
            
        }
        else
        {
            Debug.Log("Wrong Answer");
            //GetComponent<Image>().color = Color.red;
            quizManager.wrong();
        }         
    }
}


