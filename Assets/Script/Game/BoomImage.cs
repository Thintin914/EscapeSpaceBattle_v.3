using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomImage : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Act());      
    }

    IEnumerator Act()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Cos(Time.time * 50) * 8);
            transform.localScale += new Vector3(0.1f, 0.1f, 0);
            yield return null;
        }
        for (int i = 0; i < 10; i++)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Cos(Time.time * 50) * 8);
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            yield return null;
        }
        Destroy(gameObject);
    }
}
