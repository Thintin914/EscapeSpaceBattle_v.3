using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalPlayerText : MonoBehaviour
{
    Text text;
    Slider slider;

    private void Start()
    {
        text = GetComponent<Text>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    private void Update()
    {
        text.text = ": " + (Mathf.Floor(slider.value)).ToString();
    }
}
