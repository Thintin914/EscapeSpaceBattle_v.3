using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosePlayerToGame : MonoBehaviour
{
    Slider slider;
    public static int totalPlayerNumber;

    private void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        totalPlayerNumber = PlayerPrefs.GetInt("TotalPlayer", 0);
    }

    void GoCrashScene()
    {
        PlayerPrefs.SetInt("TotalPlayer", (int)slider.value);
        PlayerPrefs.Save();
        SceneManager.LoadScene("RocketCrash");
    }
}
