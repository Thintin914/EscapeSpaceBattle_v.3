using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFall : MonoBehaviour
{
    public GameObject particle;
    public GameObject[] gear;
    private int index;
    Transform[] children;

    private void OnCollisionEnter(Collision collision)
    {
        BoxCollider box = gameObject.GetComponent<BoxCollider>();
        box.enabled = false;
        for (int i = 0; i < 15; i++)
        {
            Instantiate(particle, new Vector3 (transform.position.x, transform.position.y - 10, transform.position.z), Quaternion.identity);
        }
        children = gameObject.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < children.Length; i++)
        {
            Transform child = children[i];
            if (child != transform)
            {
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.AddComponent<BoxCollider>();
                child.GetComponent<Rigidbody>().velocity = Vector3.zero;
                child.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                child.GetComponent<Rigidbody>().drag = 5;
                child.gameObject.AddComponent<DetatchedRocket>();
                child.parent = null;
            }
        }

        index = (int)Random.Range(0, 3.9f);
        Instantiate(gear[index], transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.y < -150)
        {
            Destroy(gameObject);
        }
    }
}
