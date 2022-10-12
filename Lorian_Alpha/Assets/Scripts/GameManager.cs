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

    public List<Button> yellowButtons = new List<Button>();
    public List<Button> blueButtons = new List<Button>();
    public List<Button> greenButtons = new List<Button>();
    public List<Button> redButtons = new List<Button>();

    private void Awake()
    {
        instance = this;
    }

    public void StateOn()
    {
        if(yellowButtons.Count > 0)
        {
            yellowBridgeInactive.SetActive(false);
            yellowLightInactive.SetActive(false);
            yellowBridgeActive.SetActive(true);
            yellowLightActive.SetActive(true);
        }

        if(blueButtons.Count > 0)
        {
            blueBridgeInactive.SetActive(false);
            blueLightInactive.SetActive(false);
            blueBridgeActive.SetActive(true);
            blueLightActive.SetActive(true);
        }

        if(greenButtons.Count > 0)
        {
            greenBridgeInactive.SetActive(false);
            greenLightInactive.SetActive(false);
            greenBridgeActive.SetActive(true);
            greenLightActive.SetActive(true);
        }
        
        if(redButtons.Count > 0)
        {
            redBridgeInactive.SetActive(false);
            redLightInactive.SetActive(false);
            redBridgeActive.SetActive(true);
            redLightActive.SetActive(true);
        }
    }

    public void StateOff()
    {
        if (yellowButtons.Count < 1)
        {
            yellowBridgeInactive.SetActive(true);
            yellowLightInactive.SetActive(true);
            yellowBridgeActive.SetActive(false);
            yellowLightActive.SetActive(false);
        }

        if(blueButtons.Count < 1)
        {
            blueBridgeInactive.SetActive(true);
            blueLightInactive.SetActive(true);
            blueBridgeActive.SetActive(false);
            blueLightActive.SetActive(false);
        }
        
        if(greenButtons.Count < 1)
        {
            greenBridgeInactive.SetActive(true);
            greenLightInactive.SetActive(true);
            greenBridgeActive.SetActive(false);
            greenLightActive.SetActive(false);
        }

        if(redButtons.Count < 1)
        {
            redBridgeInactive.SetActive(true);
            redLightInactive.SetActive(true);
            redBridgeActive.SetActive(false);
            redLightActive.SetActive(false);
        }
    }
}
