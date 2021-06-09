using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChoosePlayerClone : MonoBehaviour
{

    object[] obj;
    Slider slider;
    public GameObject spacesuit;
    GameObject cloneDetails;
    public Image ControllerImage;
    private Image cloneImage;
    public bool[] isSelected;
    private int maxHead;

    private void Awake()
    {
        maxHead = 5;
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }
    private void Start()
    {
        DeleteAllClone();
    }

    void DeleteAllClone()
    {
        obj = FindObjectsOfType(typeof(GameObject));

        foreach (GameObject o in obj)
        {
            GameObject g = o;
            if (g != null && g.tag == "Suit" || g.tag == "ControllerImage")
            {
                Destroy(g);
            }
        }
        CreateSpaceClone();
    }

    void CreateSpaceClone()
    {
        isSelected = new bool[maxHead];
        int total = (int)slider.value;
        int index = 0;
        int randomHead;
        for (int i = 0; i < total; i++)
        {
            do
            {
                index += 1;
                randomHead = Random.Range(0, maxHead);
            } while (isSelected[randomHead] == true && index < 25);
            isSelected[randomHead] = true;
        }
        index = -1;
        for (int i =0; i+1 <= total; i++)
        {
            bool isPicked = false;
            for (int j =index + 1; j < isSelected.Length; j++)
            {
                if (isSelected[j] == true && isPicked == false)
                {
                    isPicked = true;
                    index = j;
                    PlayerPrefs.SetInt("P" + i, j);
                }
            }  


            cloneDetails = Instantiate(spacesuit, new Vector3(-35 + (8 * i) - 1, -8.5f, 15), Quaternion.Euler(0, -180, 0));
            cloneDetails.GetComponent<spacesuitHead>().playerID = i;
            cloneDetails.GetComponent<spacesuitHead>().status = "ChoosePlayer";
            cloneImage = Instantiate(ControllerImage, new Vector3(Screen.width * 0.1f + (i - 1)  * 80, 0 + Screen.height * 0.05f,0), Quaternion.Euler(0, 0, 0));
            cloneImage.GetComponent<ControllerImage>().playerID = i;
            cloneImage.transform.SetParent(GameObject.Find("Canvas").transform, false);

        }
    }
}
