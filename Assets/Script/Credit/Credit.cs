using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine("DisplayCredit");
    }

    IEnumerator DisplayCredit()
    {
        GameObject.Find("IVE").GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(2);
        GameObject.Find("IVE").GetComponent<Image>().enabled = false;
        GameObject.Find("OurTeam").GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(2);
        GameObject.Find("OurTeam").GetComponent<Image>().enabled = false;
        SceneManager.LoadScene("MainMenu");
    }
}
