using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerImage : MonoBehaviour
{
    public int playerID;
    public Sprite[] allImages;

    private void Start()
    {
        GetComponent<Image>().sprite = allImages[playerID];
    }
}
