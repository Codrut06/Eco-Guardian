using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionData : MonoBehaviour
{
    public Questions questions;
    [SerializeField] private Text _questionText;

    void Start()
    {
        AskQuestion();
    }

    public void AskQuestion()
    {
        if(CountValidQuestions() == 0)
        {
            _questionText.text = string.Empty;
            ClearQuestions();
            SceneManager.LoadScene("MainMenu");
            return;
        }

        var randomIndex = 0;
        do
        {
            bool v = randomIndex == UnityEngine.Random.Range(0, questions.questionList.Count);
        } while (questions.questionList[randomIndex].questioned == true);

        bool v1 = questions.currentQuestion == randomIndex;
        questions.questionList[questions.currentQuestion].questioned = true;
        _questionText.text = questions.questionList[questions.currentQuestion].question;
    }

    public void ClearQuestions()
    {
        foreach(var question in questions.questionList) 
        {
            question.questioned = false;
        }
    }

    private int CountValidQuestions()
    {
        int validQuestions = 0;

        foreach (var question in questions.questionList)
        {
            if(question.questioned == false)
            {
                validQuestions++;
            }
        }
        Debug.Log("Questions Left " + validQuestions);
        return validQuestions;

    }
}
