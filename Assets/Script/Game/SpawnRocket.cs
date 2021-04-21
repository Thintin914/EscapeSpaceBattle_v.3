using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocket : MonoBehaviour
{
    public GameObject rocket;
    private GameObject clone;
    private float rotationOffset;

    private void Start()
    {
        InvokeRepeating("CreateRocket", 0, Random.Range(1, 3));
    }

    private void Update()
    {
        rotationOffset = Mathf.Sin(Time.time) * 5;
        transform.RotateAround(new Vector3(20 + rotationOffset, 100, 45 + rotationOffset), Vector3.up, 3 + rotationOffset*0.7f);
    }

    void CreateRocket()
    {
        clone = Instantiate(rocket, transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(Vector3.down * 15700);
        clone.transform.rotation = Quaternion.Euler(0, 0, -180);
        Physics.IgnoreCollision(clone.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
    }
}
