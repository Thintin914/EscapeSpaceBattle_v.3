using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spacesuitHead : MonoBehaviour
{

    public GameObject[] allHeadPrefabs;
    public string status;

    public int ori;
    public int playerID;

    private GameObject head;

    private Camera cam;
    private Button cloneButton;
    public Button headButton;


    private void Start()
    {
        ori = PlayerPrefs.GetInt("P" + playerID);
        head = Instantiate(allHeadPrefabs[ori], new Vector3 (transform.position.x, transform.position.y + 7, transform.position.z - 1), Quaternion.identity);
        head.transform.SetParent(gameObject.transform);
        if (status == "ChoosePlayer")
        {
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            cloneButton = Instantiate(headButton);
            cloneButton.transform.SetParent(GameObject.Find("Canvas").transform, false);
            cloneButton.transform.position = new Vector3(Screen.width * 0.1f + (playerID - 1) * 34,Screen.height * 0.5f,0);
            cloneButton.name = "NextHead";
            cloneButton.GetComponent<ChangeHead>().parent = gameObject;
        }
    }

    public IEnumerator EnterRocket()
    {
        for (int i = 0; i < 45; i++)
        {
            transform.Rotate(0,2,0);
            yield return null;
        }
        for (int i = 0; i < 10; i++)
        {
            transform.position += new Vector3(-1,0,0);
            yield return null;
        }
        transform.position = new Vector3(-13, 73, 64);
        transform.rotation = Quaternion.Euler(0, -180, 0);
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        transform.SetParent(GameObject.Find("Circle_002_Circle_003").transform);
        transform.parent.parent.GetChild(5).SetParent(GameObject.Find("Circle_002_Circle_003").transform);
        Transform rocket = gameObject.transform.parent;

        GameObject.Find("Main Camera").transform.SetParent(gameObject.transform);
        GameObject.Find("sea").GetComponent<Seawave>().isClickable = true;
        int temp = 1;

        for (int i = 0; i < 20; i++)
        {
            rocket.transform.position += new Vector3(0, 0.5f, 0);
            yield return null;
        }

        for (int i = 0; i< temp; i++)
        {
            rocket.transform.position += new Vector3(0, 0.5f, 0);
            yield return null;
            temp++;
        }
    }

    public void NextHead()
    {
        Destroy(gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject);
        bool isDone = false;
        int i = 0;

        int temp = ori;
        do
        {
            temp += 1;
            if (temp > allHeadPrefabs.Length - 1)
            {
                temp = 0;
            }
            if (GameObject.Find("Slider").GetComponent<ChoosePlayerClone>().isSelected[temp] == false)
            {
                isDone = true;
            }
            i++;
        } while (i < allHeadPrefabs.Length && isDone == false);

        if (i > allHeadPrefabs.Length)
            temp = ori;
        

        head = Instantiate(allHeadPrefabs[temp], new Vector3(transform.position.x, transform.position.y + 7, transform.position.z), Quaternion.identity);
        head.transform.SetParent(gameObject.transform);

        GameObject.Find("Slider").GetComponent<ChoosePlayerClone>().isSelected[ori] = false;
        GameObject.Find("Slider").GetComponent<ChoosePlayerClone>().isSelected[temp] = true;
        ori = temp;
        PlayerPrefs.SetInt("P" + playerID, ori);
    }

}
