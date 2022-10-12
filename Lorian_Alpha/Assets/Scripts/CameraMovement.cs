using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Character;
    void Start()
    {
        transform.position = new Vector3(0f, 0f, -10f);
    }

    void Update()
    {
        if (Character.transform.position.x > transform.position.x + 9)
        {
            transform.position = new Vector3(transform.position.x + 17.8019f, transform.position.y, transform.position.z);
        }

        if (Character.transform.position.x < transform.position.x - 9)
        {
            transform.position = new Vector3(transform.position.x - 17.8019f, transform.position.y, transform.position.z);
        }

        if (Character.transform.position.y > transform.position.y + 5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        }

        if (Character.transform.position.y < transform.position.y - 5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
        }
    }
}
