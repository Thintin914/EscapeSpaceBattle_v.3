using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    Renderer rend;
    public Material[] material;

    Rigidbody RB;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[Random.Range(0, 3)];
        transform.localScale = new Vector3(Random.Range(0.1f,2), Random.Range(0.1f,2), Random.Range(0.1f, 2));
        RB = GetComponent<Rigidbody>();
        RB.AddForce(Random.Range(2, 8), Random.Range(2, 8), Random.Range(2, 8));
        Destroy(gameObject, 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Planet" || collision.gameObject.name == "mapHitbox")
        {
            Destroy(gameObject);
        }
    }


}
