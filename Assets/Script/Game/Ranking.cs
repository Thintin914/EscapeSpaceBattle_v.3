using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public static int P1Score = 0;
    public static int P2Score = 0;
    public static int P3Score = 0;
    public static int P4Score = 0;
    public Text Score;
    private Text textClone;
    private int totalPlayer;
    private GameObject objClone; 
    public GameObject playerCostume;
    public Text indicator;
    private int[] playerScore;
    public int[] playerRank;


    private void Start()
    {
        totalPlayer = PlayerPrefs.GetInt("TotalPlayer");
        playerScore = new int[totalPlayer];
        playerRank = new int[totalPlayer];
        for (int i =0; i < playerRank.Length; i++)
        {
            playerRank[i] = i;
        }

            
        for (int i = 0; i < totalPlayer; i++) {
            objClone = GameObject.Find("Canvas");
            textClone = Instantiate(Score, transform.position, transform.rotation) as Text;
            textClone.transform.SetParent(objClone.transform, false);
            textClone.GetComponent<Score>().ID = i+1;

            objClone = Instantiate(playerCostume,new Vector3 (-1.3f,70+ i * 12,70), Quaternion.Euler(0, -180, 0));
            objClone.GetComponent<PlayerController>().ID = i + 1;
            objClone.GetComponent<spacesuitHead>().playerID = i;
            objClone.GetComponent<spacesuitHead>().status = "Play";
            objClone.name = "Player " + i;

            textClone = Instantiate(indicator);
            textClone.transform.SetParent(GameObject.Find("Canvas").transform, false);
            textClone.GetComponent<PlayerIndicator>().ID = i + 1;
            textClone.GetComponent<PlayerIndicator>().parent = objClone;


        }
    }

    private void LateUpdate()
    {
        playerToScore();
        playerToRank();
    }

    void playerToScore()
    {
        if (totalPlayer > 0)
            playerScore[0] = P1Score;
        if (totalPlayer > 1)
            playerScore[1] = P2Score;
        if (totalPlayer > 2)
            playerScore[2] = P3Score;
        if (totalPlayer > 3)
            playerScore[3] = P4Score;
    }

    void playerToRank()
    {
        int temp;
        for (int i = 0; i < playerScore.Length; i++)
        {
            for (int j = i; j < playerScore.Length; j++)
            {
                if (playerScore[j] > playerScore[i] && playerRank[j] > playerRank[i])
                {
                    temp = playerRank[j];
                    playerRank[j] = playerRank[i];
                    playerRank[i] = temp; ;
                }
                else if (playerScore[j] < playerScore[i] && playerRank[j] < playerRank[i])
                {
                    temp = playerRank[j];
                     playerRank[j] = playerRank[i];
                    playerRank[i] = temp;
                }
                
            }
        }
    }
}
