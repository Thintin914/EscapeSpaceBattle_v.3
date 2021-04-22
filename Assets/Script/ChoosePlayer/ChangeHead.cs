using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHead : MonoBehaviour
{
    public GameObject parent;

    private void PressToNextHead()
    {
        parent.GetComponent<spacesuitHead>().NextHead();
    }

}
