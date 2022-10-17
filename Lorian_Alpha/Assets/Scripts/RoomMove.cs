using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private OtherCameraMovement otherCam;

    void Start()
    {
        otherCam = Camera.main.GetComponent<OtherCameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            otherCam.minPosition += cameraChange;
            otherCam.maxPosition += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
