using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    public GameObject fadeFromBlack;
    
    void Start()
    {
        if (fadeFromBlack != null)
        {
            GameObject panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1.5f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
