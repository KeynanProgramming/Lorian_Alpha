using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private OtherCameraMovement otherCam;
    public int counter;
    public GameObject cam1;
    public GameObject cam2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian player = collision.gameObject.GetComponent<Lorian>();

        if (collision != null && counter == 0)
        {
            cam2.gameObject.SetActive(true);
            cam1.gameObject.SetActive(false);
            counter++;
            otherCam = GetComponent<OtherCameraMovement>();
            /*otherCam.minPosition += cameraChange;
            otherCam.maxPosition += cameraChange;
            collision.transform.position += playerChange;*/
        }
        else if(collision != null && counter == 1)
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
            counter--;
        }
    }
}
