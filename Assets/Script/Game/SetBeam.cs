using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBeam : MonoBehaviour
{
    public GameObject beam;
    public void Start()
    {
        InvokeRepeating("CreateBeam", 0, Random.Range(3f, 8f));
    }

    public void CreateBeam()
    {
        Instantiate(beam, transform.position, Quaternion.identity);
    }
}
