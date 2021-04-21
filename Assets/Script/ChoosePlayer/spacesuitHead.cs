using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        head = Instantiate(allHeadPrefabs[ori], new Vector3 (transform.position.x, transform.position.y + 7, transform.position.z), Quaternion.identity);        head.transform.SetParent(gameObject.transform);
        if (status == "ChoosePlayer")
        {
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            Vector3 screenPos = cam.WorldToScreenPoint(transform.position);
            cloneButton = Instantiate(headButton);
            cloneButton.transform.SetParent(GameObject.Find("Canvas").transform, false);
            cloneButton.transform.position = new Vector3(screenPos.x,screenPos.y + 185, screenPos.z);
            cloneButton.name = "NextHead";
            cloneButton.GetComponent<ChangeHead>().parent = gameObject;
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
