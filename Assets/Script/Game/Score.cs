using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int ID;
    private int score;
    private int pastRank;
    private Vector3 startPos;
    private int currentRank;
    private Image imageClone;
    public Image icon;

    private void Start()
    {
        transform.position = new Vector3(150, Screen.height * 0.5f + (ID - 1) * -50, 1);
        imageClone = Instantiate(icon, Vector3.zero,Quaternion.identity);
        imageClone.transform.SetParent(gameObject.transform, false);
        pastRank = GameObject.Find("Rank").GetComponent<Ranking>().playerRank[ID - 1];
    }

    private void FixedUpdate()
    {
        switch (ID)
        {
            case 1:
                score = Ranking.P1Score;
                break;
            case 2:
                score = Ranking.P2Score;
                break;
            case 3:
                score = Ranking.P3Score;
                break;
            case 4:
                score = Ranking.P4Score;
                break;
        }
        GetComponent<Text>().text = "#P" + (ID).ToString() + ": " + (score).ToString();
        if (currentRank == pastRank)
        {
            currentRank = GameObject.Find("Rank").GetComponent<Ranking>().playerRank[ID - 1];
            startPos = transform.position;
        }
        else
        {
            StartCoroutine(Lerp(0.1f));        
        }
        
    }

    IEnumerator Lerp(float portion)
    {
        float movedPortion = 0;
        while (movedPortion < portion)
        {
            transform.position = Vector3.Lerp(startPos, new Vector3(150, Screen.height * 0.5f + currentRank * -50, 1), movedPortion/portion);
            movedPortion += Time.deltaTime;
            yield return null;
        }
        pastRank = currentRank;
    }
}
