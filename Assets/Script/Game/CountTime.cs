using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTime : MonoBehaviour
{
    float seconds;
    float maxSeconds;
    private int[] allScores = new int[4];
    private int highestPlayer;
    private TMPro.TextMeshProUGUI textClone;
    public TMPro.TextMeshProUGUI winningText;
    private GameObject objClone; 

    private void Start()
    {
        maxSeconds = 60;
    }

    private void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = (seconds).ToString("0.0");
        seconds = maxSeconds - Time.time;
        if (seconds <= 0)
        {
            collectScore();
            int max = 0;
            for(int i =0; i< allScores.Length; i++)
            {
                if (allScores[i] > max)
                    max = allScores[i];
            }

            for (int i =0; i < allScores.Length; i++)
            {
                if (max == allScores[i])
                {
                    highestPlayer = i + 1;
                }
            }
            Time.timeScale = 0;
            objClone = GameObject.Find("Canvas");
            textClone = Instantiate(winningText);
            textClone.text = "Player " + highestPlayer + " victory!";
            textClone.transform.SetParent(objClone.transform, false);
            GetComponent<CountTime>().enabled = false;

        }
    }

    void collectScore()
    {
        allScores[0] = Ranking.P1Score;
        allScores[1] = Ranking.P2Score;
        allScores[2] = Ranking.P3Score;
        allScores[3] = Ranking.P4Score;
    }
}
