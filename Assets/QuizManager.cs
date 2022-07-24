using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public List <QuestionsandAnswers> QnA;
    public GameObject[]  options;
    public int currentQuestion;

    public TMP_Text QuestionTxt;
    public TMP_Text ScoreTxt;

    int TotalQuestion = 0;
    public int score;


    
    public GameObject Quizpanel;
    public GameObject GoPanel;

    private void Start ()
    {
        TotalQuestion = QnA.Count;

        GoPanel.SetActive(false);
        generateQuestion();

    }

    public void retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    
     void GameOver ()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text =  score + "/" + TotalQuestion;
    }
    public void correct()

    {
        //when you are right
        score +=1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        
        
    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        generateQuestion();


    }

    void SetAnswers()
    {
        for (int i=0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;

            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
        //currentQuestion = Random.Range(0, QnA.Count);

        //currentQuestion = QnA.Count[i];

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();

        }
        else
        {
        Debug.Log("Out of Questions");
        GameOver();

        }
        
    }
}
