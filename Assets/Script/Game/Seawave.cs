using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Seawave : MonoBehaviour
{
    private float offset;
    public bool isClickable = false;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SpinMap")
        {
            offset = Mathf.Sin(Time.time) * 15;
            transform.position = new Vector3(0, 15 + offset, 0);
        }
        if (SceneManager.GetActiveScene().name == "Winning")
        {
            transform.position += new Vector3(0,0.3f,0);

            if (isClickable == true && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
