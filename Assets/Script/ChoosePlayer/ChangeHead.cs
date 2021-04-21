using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHead : MonoBehaviour
{
    public GameObject parent;
    private RectTransform rectancle;

    private void Start()
    {
        rectancle = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 localMousePosition = rectancle.InverseTransformPoint(Input.mousePosition);
        if (rectancle.rect.Contains(localMousePosition))
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }

    private void PressToNextHead()
    {
        parent.GetComponent<spacesuitHead>().NextHead();
    }

}
