using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int ID;
    public CharacterController controller;
    private Vector3 direction;
    private float speed = 20f;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public GameObject bubble;
    public bool isDead = false;

    private string front;
    private string back;
    private string left;
    private string right;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "SpinMap"){
            enabled = false;
        }
    }

    void SetInputKeys(string front, string back, string left, string right)
    {
        this.front = front;
        this.back = back;
        this.left = left;
        this.right = right;
    }

    private void Start()
    {
        switch (ID)
        {
            case 1:
                SetInputKeys("w", "s", "a", "d");
                break;
            case 2:
                SetInputKeys("up", "down", "left", "right");
                break;
            case 3:
                SetInputKeys("i", "k", "j", "l");
                break;
            case 4:
                SetInputKeys("[5]", "[2]", "[1]", "[3]");
                break;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Suit")
            hit.gameObject.GetComponent<CharacterController>().Move(direction * speed * Time.deltaTime);
        if (hit.gameObject.tag == "Rocket")
            StartCoroutine(WaitSpawn(transform.position, 2));
    }

    private void Update()
    {
        if (isDead == false)
        {
            float horizontal = 0;
            float vertical = 0;
            if (Input.GetKey(front))
            {
                vertical = 1;
            }
            if (Input.GetKey(back))
            {
                vertical = -1;
            }
            if (Input.GetKey(left))
            {
                horizontal = -1;
            }
            if (Input.GetKey(right))
            {
                horizontal = 1;
            }
            direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0, angle, 0);

                controller.Move(direction * speed * Time.deltaTime);
            }
            controller.Move(new Vector3(0, -0.5f, 0));

            if (transform.position.y < -25)
            {
                StartCoroutine(WaitSpawn(new Vector3(-1.3f, 80 + ID * 12, 70), 4));
            }
        }

    }

    public IEnumerator WaitSpawn(Vector3 spawnPoint, float waitSec)
    {
        isDead = true;
        enabled = false;
        controller.enabled = false;
        GameObject cloneBubble = Instantiate(bubble, spawnPoint, Quaternion.identity);
        transform.position = new Vector3(spawnPoint.x, spawnPoint.y - 5, spawnPoint.z);
        gameObject.transform.SetParent(cloneBubble.transform);
        yield return new WaitForSeconds(waitSec);
        gameObject.transform.parent = null;
        enabled = true;
        controller.enabled = true;
        isDead = false;
        Destroy(cloneBubble);
    }
}
