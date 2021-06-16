using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector3(0.1f, 250, 0.1f);
        StartCoroutine("WaitDelete");
    }

    public void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    IEnumerator WaitDelete()
    {
        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.localScale += new Vector3(0.1f, 0, 0.1f);
        }
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }
}
