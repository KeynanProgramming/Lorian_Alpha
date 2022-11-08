using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator buttonAnimation;

    void Start()
    {
        buttonAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D pushing)
    {
        MovableObject statueOnButton = pushing.GetComponent<MovableObject>();

        if(statueOnButton != null)
        {
            buttonAnimation.SetBool("Pushed", true);

            switch (gameObject.tag)
            {
                case "YellowButton":
                    GameManager.instance.yellowButtonsPushed.Add(this);
                    break;

                case "BlueButton":
                    GameManager.instance.blueButtonsPushed.Add(this);
                    break;

                case "GreenButton":
                    GameManager.instance.greenButtonsPushed.Add(this);
                    break;

                case "RedButton":
                    GameManager.instance.redButtonsPushed.Add(this);
                    break;

                case "OrangeButton":
                    GameManager.instance.orangeButtonsPushed.Add(this);
                    break;

                case "DoorOneButton":
                    GameManager.instance.doorOneButtonsPushed.Add(this);
                    break;

                case "DoorTwoButton":
                    GameManager.instance.doorTwoButtonsPushed.Add(this);
                    break;
            }

            GameManager.instance.StateOn();
        }
    }

    private void OnTriggerExit2D(Collider2D notPushing)
    {
        MovableObject statueAway = notPushing.GetComponent<MovableObject>();

        if(statueAway != null)
        {
            buttonAnimation.SetBool("Pushed", false);

            switch (gameObject.tag)
            {
                case "YellowButton":
                    GameManager.instance.yellowButtonsPushed.Remove(this);
                    break;

                case "BlueButton":
                    GameManager.instance.blueButtonsPushed.Remove(this);
                    break;

                case "GreenButton":
                    GameManager.instance.greenButtonsPushed.Remove(this);
                    break;

                case "RedButton":
                    GameManager.instance.redButtonsPushed.Remove(this);
                    break;

                case "OrangeButton":
                    GameManager.instance.orangeButtonsPushed.Remove(this);
                    break;

                case "DoorOneButton":
                    GameManager.instance.doorOneButtonsPushed.Remove(this);
                    break;

                case "DoorTwoButton":
                    GameManager.instance.doorTwoButtonsPushed.Remove(this);
                    break;
            }

            GameManager.instance.StateOff();
        }
    }
}
