using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    public GameObject spacesuit;
    private GameObject cloneSpacesuit;

    private void Start()
    {
        int temp = 0;
        for (int i = 0; i < PlayerPrefs.GetInt("TotalPlayer"); i ++)
        {
            if (i != PlayerPrefs.GetInt("Winner") - 1)
            {
                cloneSpacesuit = Instantiate(spacesuit, new Vector3(-10 + (temp - 1) * 10, 52, 40 + Random.Range(-20, 20)), Quaternion.Euler(0, -180, 0));
                cloneSpacesuit.GetComponent<spacesuitHead>().playerID = i;
                temp++;
            }
        }

        cloneSpacesuit = Instantiate(spacesuit, new Vector3(0,66,65), Quaternion.Euler(0, -180, 0));
        cloneSpacesuit.GetComponent<spacesuitHead>().playerID = PlayerPrefs.GetInt("Winner") - 1;
        StartCoroutine(cloneSpacesuit.GetComponent<spacesuitHead>().EnterRocket());


    }
}
