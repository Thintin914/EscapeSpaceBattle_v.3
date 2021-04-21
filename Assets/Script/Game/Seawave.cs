using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seawave : MonoBehaviour
{
    private float offset;

    private void Update()
    {
        offset = Mathf.Sin(Time.time) * 15;
        transform.position = new Vector3(0,15 + offset,0);
    }
}
