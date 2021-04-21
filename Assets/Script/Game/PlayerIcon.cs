using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIcon : MonoBehaviour
{
    public Sprite[] allSprites;

    private void Start()
    {
        int num = GetComponentInParent<Score>().ID - 1;
        GetComponent<Image>().sprite = allSprites[PlayerPrefs.GetInt("P" + num)];
    }
}
