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
                    GameManager.instance.yellowButtons.Add(this);
                    break;

                case "BlueButton":
                    GameManager.instance.blueButtons.Add(this);
                    break;

                case "GreenButton":
                    GameManager.instance.greenButtons.Add(this);
                    break;

                case "RedButton":
                    GameManager.instance.redButtons.Add(this);
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
                    GameManager.instance.yellowButtons.Remove(this);
                    break;

                case "BlueButton":
                    GameManager.instance.blueButtons.Remove(this);
                    break;

                case "GreenButton":
                    GameManager.instance.greenButtons.Remove(this);
                    break;

                case "RedButton":
                    GameManager.instance.redButtons.Remove(this);
                    break;
            }

            GameManager.instance.StateOff();
        }
    }
}
