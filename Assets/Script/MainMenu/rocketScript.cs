using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour
{

    public GameObject logo;
    public string status = "Opening";
    private float velocity = 6000.0f;

    void Update()
    {

        if (status == "Opening")
        {
            Opening();
        }
        if (status == "Zoom")
        {
            transform.position = new Vector3(500, 500, 600);
        }
        
        transform.Rotate(0, 2, 0, Space.Self);

    }

    void Opening ()
    {
        
        transform.Translate(0, velocity * Time.deltaTime, 0);
        transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f) * Time.deltaTime;
        velocity = velocity * 0.9f;
        if (Mathf.Floor(velocity) < 1)
        {
            status = "End";
            logo.SetActive(true);
        }
    }
}
