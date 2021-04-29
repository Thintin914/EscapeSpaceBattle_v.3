using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIndicator : MonoBehaviour
{
    public int ID;
    public GameObject parent;
    Camera cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        GetComponent<Text>().text = "P" + ID;
    }


    private void Update()
    {
            transform.position = cam.WorldToScreenPoint(parent.GetComponent<Transform>().position);
            transform.position = new Vector3(transform.position.x - 30, transform.position.y + 80, transform.position.z);
    }
}
