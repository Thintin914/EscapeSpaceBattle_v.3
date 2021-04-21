using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraShake : MonoBehaviour
{
    public bool isShake;

    private void Start()
    {
        isShake = false;
    }

    private void Update()
    {
        if (isShake == true)
        {
            transform.rotation = Quaternion.Euler(0 + Random.Range(-5, 5), 0 + Random.Range(-5, 5), 0 + Random.Range(-5, 5));
            StartCoroutine(WaitAndEnd());
        }
    }

    IEnumerator WaitAndEnd()
    {
        yield return new WaitForSeconds(1.5f);
        isShake = false;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SpinMap");
    }
}
