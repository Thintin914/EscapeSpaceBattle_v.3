using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMovement : MonoBehaviour
{
    private Text text;
    private GameObject canvas;
    rocketScript rocket;

    private void Start()
    {
        text = GetComponent<Text>();
        canvas = GameObject.Find("Canvas");
        rocket = GameObject.Find("rocket").GetComponent<rocketScript>();
    }

    private void Update()
    {
        Vector3 pos = new Vector3(0, Screen.height * 0.25f + Mathf.Cos(Time.time * 8) * 15, 1);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Cos(Time.time * 8) * 8);
        if (Mathf.Floor(Time.time) % 2 == 0)
        {
            text.text = "Press Any To Start";
        }
        else
        {
            text.text = "<Press Any To Start>";
        }
        if (Input.anyKey)
        {
            rocket.status = "Zoom";
            canvas.SetActive(false);
            gameObject.GetComponent<TextMovement>().enabled = false;
        }
    }

}
