using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]

public class CameraInGameMovement : MonoBehaviour
{

    private Transform[] targets;
    object[] obj;

    public Vector3 offset;
    public float smoothTime = 0.5f;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
        targets = new Transform[PlayerPrefs.GetInt("TotalPlayer")];
        int playerToIndex = 0;

        obj = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (GameObject o in obj)
        {
            GameObject g = o;
            if (g != null && g.tag == "Suit")
            {;
                targets[playerToIndex] = g.transform;
                playerToIndex += 1;
            }
        }
    }


    private void LateUpdate()
    {
        if (targets.Length == 0)
            return;
        Move();
        Zoom();
    }
    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i =0; i< targets.Length; i++)
        {
            if (targets[i].GetComponent<PlayerController>().isDead == false)
                bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    Vector3 GetCenterPoint()
    {
        if (targets.Length == 1)
        {
            if (targets[0].GetComponent<PlayerController>().isDead == false)
            {
                return targets[0].position;
            }
            else
            {
                return new Vector3(0, 70, 0);
            }
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].GetComponent<PlayerController>().isDead == false)
                bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }


}
