using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCopy : MonoBehaviour
{
    public GameObject buttonActive,
                      buttonInactive,
                      bridgeActive, 
                      bridgeInactive,
                      lightActive,
                      lightInactive;

    private void OnTriggerEnter2D(Collider2D pushing)
    {
        MovableObject statueOnButton = pushing.GetComponent<MovableObject>();

        if(statueOnButton != null)
        {
            buttonInactive.SetActive(false);
            bridgeInactive.SetActive(false);
            lightInactive.SetActive(false);
            buttonActive.SetActive(true);
            bridgeActive.SetActive(true);
            lightActive.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D notPushing)
    {
        MovableObject statueAway = notPushing.GetComponent<MovableObject>();

        if(statueAway != null)
        {
            buttonInactive.SetActive(true);
            bridgeInactive.SetActive(true);
            lightInactive.SetActive(true);
            buttonActive.SetActive(false);
            bridgeActive.SetActive(false);
            lightActive.SetActive(false);
        }
    }
}
