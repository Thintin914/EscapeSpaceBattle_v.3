using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketCrash : MonoBehaviour
{
    public GameObject particle;
    cameraShake cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<cameraShake>();
    }

    private void Update()
    {
        transform.Translate(0, 250f*Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        cam.isShake = true;
        for (int i = 0; i < 35; i++)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
