using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultManager : MonoBehaviour
{

    [SerializeField]
    private Text correctNumberText, wrongNumberText, scoreText;

    [SerializeField]
    private GameObject leftStar, middleStar, rightStar;




    public void WriteResults(int correctNumber, int wrongNumber, int totalScore)
    {

        correctNumberText.text = correctNumber.ToString();
        wrongNumberText.text = wrongNumber.ToString();
        scoreText.text = totalScore.ToString();

        leftStar.SetActive(false);
        middleStar.SetActive(false);
        rightStar.SetActive(false);

        if (totalScore > 0 && totalScore <= 600)
        {
            leftStar.SetActive(true);
        }
        else if (totalScore > 600 && totalScore <= 1200)
        {
            leftStar.SetActive(true);
            middleStar.SetActive(true);
        }
        else if (totalScore > 1200)
        {
            leftStar.SetActive(true);
            middleStar.SetActive(true);
            rightStar.SetActive(true);

        }
        else
        {
            totalScore = 0;
            scoreText.text = totalScore.ToString();

            leftStar.SetActive(false);
            middleStar.SetActive(false);
            rightStar.SetActive(false);
        }


        Debug.Log("Total Score : " + totalScore);


    }

    public void StartAgain()
    {
        SceneManager.LoadScene("GamePlay");


    }

}
