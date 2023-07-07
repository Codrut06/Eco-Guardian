using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizzMaster : MonoBehaviour
{
    public GameObject butonCorect;
    public GameObject butonGresit;

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count ==0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact; ;

    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        
        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        butonCorect.SetActive(true);
        butonGresit.SetActive(true);
    }

    public void UserSelecTrue()
    {
        if(currentQuestion.isTrue)
        {
            Debug.Log("Correct");
            butonGresit.SetActive(false);
            butonCorect.SetActive(true) ;
        }
        else
        {
            Debug.Log("Wrong");
            butonGresit.SetActive(true);
            butonCorect.SetActive(false);
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        if(!currentQuestion.isTrue)
        {
            Debug.Log("Correct");
            butonCorect.SetActive(false);
            butonGresit.SetActive(true);
        }
        else
        {
            Debug.Log("Wrong");
            butonGresit.SetActive(false);
            butonCorect.SetActive(true);
        }

        StartCoroutine(TransitionToNextQuestion());

    }
}
