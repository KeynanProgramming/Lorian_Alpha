using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject yellowBridgeActive,
                      yellowBridgeInactive,
                      yellowLightActive,
                      yellowLightInactive,
                      blueBridgeActive,
                      blueBridgeInactive,
                      blueLightActive,
                      blueLightInactive,
                      greenBridgeActive,
                      greenBridgeInactive,
                      greenLightActive,
                      greenLightInactive,
                      redBridgeActive,
                      redBridgeInactive,
                      redLightActive,
                      redLightInactive;


    public List<Button> yellowButtonsPushed = new List<Button>();
    public List<Button> blueButtonsPushed = new List<Button>();
    public List<Button> greenButtonsPushed = new List<Button>();
    public List<Button> redButtonsPushed = new List<Button>();
    //public List<Button> orangeButtons = new List<Button>();
    public int buttonsNeeded;

    private void Awake()
    {
        instance = this;
    }

    public void StateOn()
    {
        if(yellowButtonsPushed.Count >= buttonsNeeded)
        {
            yellowBridgeInactive.SetActive(false);
            yellowLightInactive.SetActive(false);
            yellowBridgeActive.SetActive(true);
            yellowLightActive.SetActive(true);
        }

        if(blueButtonsPushed.Count >= buttonsNeeded)
        {
            blueBridgeInactive.SetActive(false);
            blueLightInactive.SetActive(false);
            blueBridgeActive.SetActive(true);
            blueLightActive.SetActive(true);
        }

        if(greenButtonsPushed.Count >= buttonsNeeded)
        {
            greenBridgeInactive.SetActive(false);
            greenLightInactive.SetActive(false);
            greenBridgeActive.SetActive(true);
            greenLightActive.SetActive(true);
        }
        
        if(redButtonsPushed.Count >= buttonsNeeded)
        {
            redBridgeInactive.SetActive(false);
            redLightInactive.SetActive(false);
            redBridgeActive.SetActive(true);
            redLightActive.SetActive(true);
        }

        /*if (orangeButtons.Count >= buttonsNeeded)
        {
            orangeBridgeInactive.SetActive(false);
            orangeLightInactive.SetActive(false);
            orangeBridgeActive.SetActive(true);
            orangeLightActive.SetActive(true);
        }*/
    }

    public void StateOff()
    {
        if (yellowButtonsPushed.Count < buttonsNeeded)
        {
            yellowBridgeInactive.SetActive(true);
            yellowLightInactive.SetActive(true);
            yellowBridgeActive.SetActive(false);
            yellowLightActive.SetActive(false);
        }

        if(blueButtonsPushed.Count < buttonsNeeded)
        {
            blueBridgeInactive.SetActive(true);
            blueLightInactive.SetActive(true);
            blueBridgeActive.SetActive(false);
            blueLightActive.SetActive(false);
        }
        
        if(greenButtonsPushed.Count < buttonsNeeded)
        {
            greenBridgeInactive.SetActive(true);
            greenLightInactive.SetActive(true);
            greenBridgeActive.SetActive(false);
            greenLightActive.SetActive(false);
        }

        if(redButtonsPushed.Count < buttonsNeeded)
        {
            redBridgeInactive.SetActive(true);
            redLightInactive.SetActive(true);
            redBridgeActive.SetActive(false);
            redLightActive.SetActive(false);
        }

        /*if (orangeButtons.Count < buttonsNeeded)
        {
            orangeBridgeInactive.SetActive(true);
            orangeLightInactive.SetActive(true);
            orangeBridgeActive.SetActive(false);
            orangeLightActive.SetActive(false);
        }*/
    }
}
