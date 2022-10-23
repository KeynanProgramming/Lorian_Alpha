using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    /*public Vector2 cameraChange;
    public Vector3 playerChange;
    private OtherCameraMovement otherCam;*/
    public int counter;
    //public GameObject cam1;
    //public GameObject cam2;


    private void OnTriggerEnter2D(Collider2D other)
    {
        //otherCam = GetComponent<OtherCameraMovement>();
        //Lorian player = other.GetComponent<Lorian>();

        if(other.CompareTag("Player") && counter == 0)
        {
            /*otherCam.minPosition += cameraChange;
            otherCam.maxPosition += cameraChange;
            other.transform.position += playerChange;*/
            /*cam2.gameObject.SetActive(true);
            cam1.gameObject.SetActive(false);*/
            counter++;
        }

        if(other.CompareTag("Player") && counter == 1)
        {
            /*cam2.gameObject.SetActive(false);
            cam1.gameObject.SetActive(true);*/
            counter--;
        }
    }
}
