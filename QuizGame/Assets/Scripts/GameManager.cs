using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public Question[] questions;

    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Text correctAnswerText, wrongAnswerText;

    [SerializeField]
    private GameObject correctButton, wrongButton;

    [SerializeField]
    private Transform happyEmojiImage, sadEmojiImage;





    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    int correctCount, wrongCount;




    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();

        }
        correctCount = 0;
        wrongCount = 0;
        chooseRandomQuestion();


    }

    void chooseRandomQuestion()
    {

        correctButton.GetComponent<RectTransform>().DOLocalMoveX(-320f, 0.2f);
        wrongButton.GetComponent<RectTransform>().DOLocalMoveX(320f, 0.2f);


        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;

        if (currentQuestion.isTrue)
        {
            correctAnswerText.text = "YOU ANSWERED CORRECTLY";
            wrongAnswerText.text = "YOU ANSWERED WRONG";

        }
        else
        {
            correctAnswerText.text = "YOU ANSWERED WRONG";
            wrongAnswerText.text = "YOU ANSWERED CORRECTLY";

        }
        happyEmojiImage.transform.GetComponent<RectTransform>().DOScale(0, 0.2f);
        sadEmojiImage.transform.GetComponent<RectTransform>().DOScale(0, 0.2f);


    }

    IEnumerator waitBetweenQuestions()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(1f);
        if (unansweredQuestions.Count <= 0)
        {
            Debug.Log("Correct Count : "+correctCount);
            Debug.Log("Wrong Count : "+wrongCount);
            Debug.Log("Result Panel");
        }
        else
        {
            chooseRandomQuestion();
        }


    }
    public void correctButtonClicked()
    {

        if (currentQuestion.isTrue)
        {

            correctCount++;
            Debug.Log("Correct!!");
            happyEmojiImage.transform.GetComponent<RectTransform>().DOScale(1, 0.3f);



        }
        else
        {

            wrongCount++;
            Debug.Log("Wrong!!");
            sadEmojiImage.transform.GetComponent<RectTransform>().DOScale(1, 0.3f);

        }
        wrongButton.GetComponent<RectTransform>().DOLocalMoveX(2000, 0.5f);

        StartCoroutine(waitBetweenQuestions());
    }
    public void wrongButtonClicked()
    {
        if (!currentQuestion.isTrue)
        {
            correctCount++;
            Debug.Log("Correct!!");
            happyEmojiImage.transform.GetComponent<RectTransform>().DOScale(1, 0.3f);

        }
        else
        {
            wrongCount++;
            Debug.Log("Wrong!!");
            sadEmojiImage.transform.GetComponent<RectTransform>().DOScale(1, 0.3f);
        }
        correctButton.GetComponent<RectTransform>().DOLocalMoveX(-2000, 0.5f);
        StartCoroutine(waitBetweenQuestions());
    }
}
