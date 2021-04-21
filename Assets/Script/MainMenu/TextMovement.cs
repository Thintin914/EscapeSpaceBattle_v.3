using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMovement : MonoBehaviour
{
    public RectTransform m_parent;
    public Camera m_uiCamera;
    public RectTransform m_image;
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
        Vector2 anchoredPos;
        Vector3 pos = new Vector3(653, 80 + Mathf.Cos(Time.time * 8) * 15, 0);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Cos(Time.time * 8) * 8);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_parent, pos, m_uiCamera, out anchoredPos);
        m_image.anchoredPosition = anchoredPos;
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
