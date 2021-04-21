using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetatchedRocket : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("Shrink");
    }

    IEnumerator Shrink()
    {
        for (int i = 0; i < 25; i++)
        {
            yield return null;
            transform.localScale += new Vector3(-0.2f, -0.2f, -0.2f);
        }
        Destroy(gameObject, 0.5f);
    }
}
