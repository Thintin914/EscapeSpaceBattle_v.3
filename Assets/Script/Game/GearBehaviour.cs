using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBehaviour : MonoBehaviour
{
    GameObject[] players;
    private int ID;


    private void Start()
    {
        if (transform.parent == null)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = true;


        }
        players = GameObject.FindGameObjectsWithTag("Suit");
        StartCoroutine("CancelKin");
        StartCoroutine("WaitDestroy");
    }

    IEnumerator CancelKin()
    {
        yield return new WaitForSeconds(0.2f);
        if (transform.parent == null)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        }
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Suit")
        {
            ID = other.GetComponent<PlayerController>().ID;
            switch (getName())
            {
                case "rocketsheet1(Clone)":
                    AddScore(17);
                    break;
                case "rocketsheet2(Clone)":
                    AddScore(25);
                    break;
                case "box(Clone)":
                    AddScore(12);
                    break;
                case "chilun(Clone)":
                    AddScore(13);
                    break;
            }

            End();
        }
    }

    private string getName()
    {
        if (transform.parent == null)
        {
            return gameObject.name;
        }
        else
        {
            return transform.parent.name;
        }
    }

    private void AddScore(int score)
    {
        switch (ID)
        {
            case 1:
                Ranking.P1Score += score;
                break;
            case 2:
                Ranking.P2Score += score;
                break;
            case 3:
                Ranking.P3Score += score;
                break;
            case 4:
                Ranking.P4Score += score;
                break;
        }
    }

    private void End()
    {
        if (transform.parent == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(6);
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        End();
    }
}
