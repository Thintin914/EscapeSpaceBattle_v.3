using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollowRocketMovement : MonoBehaviour
{

    private GameObject theRocket;
    private Vector3 rocketPosition;

    // Start is called before the first frame update
    void Start()
    {
        theRocket = GameObject.Find("rocket"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (theRocket.GetComponent<rocketScript>().status == "Opening")
        {
            rocketPosition = theRocket.transform.position;
            transform.LookAt(rocketPosition);
        }
        if (theRocket.GetComponent<rocketScript>().status == "Zoom")
        {
            rocketPosition = theRocket.transform.position;
            transform.LookAt(rocketPosition);
            transform.position = Vector3.MoveTowards(transform.position, rocketPosition, 10f);
            if (Vector3.Distance(transform.position,rocketPosition) < 0.01f)
            {
                SceneManager.LoadScene("ChoosePlayer");
            }
        }
    }
}
