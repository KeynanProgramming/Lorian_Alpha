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
                      redLightInactive,
                      orangeBridgeActive,
                      orangeBridgeInactive,
                      orangeLightActive,
                      orangeLightInactive;


    public List<Button> yellowButtons = new List<Button>();
    public List<Button> blueButtons = new List<Button>();
    public List<Button> greenButtons = new List<Button>();
    public List<Button> redButtons = new List<Button>();
    public List<Button> orangeButtons = new List<Button>();
    public int buttonsNeeded = 2;

    private void Awake()
    {
        instance = this;
    }

    public void StateOn()
    {
        if(yellowButtons.Count >= buttonsNeeded)
        {
            yellowBridgeInactive.SetActive(false);
            yellowLightInactive.SetActive(false);
            yellowBridgeActive.SetActive(true);
            yellowLightActive.SetActive(true);
        }

        if(blueButtons.Count >= buttonsNeeded)
        {
            blueBridgeInactive.SetActive(false);
            blueLightInactive.SetActive(false);
            blueBridgeActive.SetActive(true);
            blueLightActive.SetActive(true);
        }

        if(greenButtons.Count >= buttonsNeeded)
        {
            greenBridgeInactive.SetActive(false);
            greenLightInactive.SetActive(false);
            greenBridgeActive.SetActive(true);
            greenLightActive.SetActive(true);
        }
        
        if(redButtons.Count >= buttonsNeeded)
        {
            redBridgeInactive.SetActive(false);
            redLightInactive.SetActive(false);
            redBridgeActive.SetActive(true);
            redLightActive.SetActive(true);
        }

        if (orangeButtons.Count >= buttonsNeeded)
        {
            orangeBridgeInactive.SetActive(false);
            orangeLightInactive.SetActive(false);
            orangeBridgeActive.SetActive(true);
            orangeLightActive.SetActive(true);
        }
    }

    public void StateOff()
    {
        if (yellowButtons.Count < buttonsNeeded)
        {
            yellowBridgeInactive.SetActive(true);
            yellowLightInactive.SetActive(true);
            yellowBridgeActive.SetActive(false);
            yellowLightActive.SetActive(false);
        }

        if(blueButtons.Count < buttonsNeeded)
        {
            blueBridgeInactive.SetActive(true);
            blueLightInactive.SetActive(true);
            blueBridgeActive.SetActive(false);
            blueLightActive.SetActive(false);
        }
        
        if(greenButtons.Count < buttonsNeeded)
        {
            greenBridgeInactive.SetActive(true);
            greenLightInactive.SetActive(true);
            greenBridgeActive.SetActive(false);
            greenLightActive.SetActive(false);
        }

        if(redButtons.Count < buttonsNeeded)
        {
            redBridgeInactive.SetActive(true);
            redLightInactive.SetActive(true);
            redBridgeActive.SetActive(false);
            redLightActive.SetActive(false);
        }

        if (orangeButtons.Count < buttonsNeeded)
        {
            orangeBridgeInactive.SetActive(true);
            orangeLightInactive.SetActive(true);
            orangeBridgeActive.SetActive(false);
            orangeLightActive.SetActive(false);
        }
    }
}
