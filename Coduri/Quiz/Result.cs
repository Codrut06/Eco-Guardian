using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Text;

public class Result : MonoBehaviour
{
    public Questions questions;
    public GameObject correctSprite;
    public GameObject badSprite;

    public Scores scores;

    public Button trueButton;
    public Button falseButton;

    public UnityEvent onNextQuestion;
    void Start()
    {
        correctSprite.SetActive(false);
        badSprite.SetActive(false);
    }

    public void ShowResults(bool answer)
    {
        correctSprite.SetActive(questions.questionList[questions.currentQuestion].isTrue == answer);
        badSprite.SetActive(questions.questionList[questions.currentQuestion].isTrue != answer);

        if (questions.questionList[questions.currentQuestion].isTrue == answer)
        {
            scores.AddScore();
        }
        else
        {
            scores.DeductScore();
        }

        trueButton.interactable = false;
        falseButton.interactable = false;

        StartCoroutine(ShowResult());
    }

    private IEnumerator ShowResult()
    {
        yield return new WaitForSeconds(1.0f);

        trueButton.interactable = true;
        falseButton.interactable = true;

        onNextQuestion.Invoke();
    }
}
