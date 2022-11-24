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
                      entranceBridgeActive,
                      entranceBridgeInactive,
                      entraceDoor,
                      secondDoor,
                      elevatorActivated;

    public List<Button> yellowButtonsPushed = new List<Button>();
    public List<Button> blueButtonsPushed = new List<Button>();
    public List<Button> greenButtonsPushed = new List<Button>();
    public List<Button> redButtonsPushed = new List<Button>();
    public List<Button> orangeButtonsPushed = new List<Button>();
    public List<Button> doorOneButtonsPushed = new List<Button>();
    public List<Button> doorTwoButtonsPushed = new List<Button>();

    public int buttonsNeeded;
    public bool redLight, greenLight, blueLight, yellowLight;

    public GameObject uIBlueLight, uIGreenLight, uIRedLight, uIYellowLight;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (redLight == true && greenLight == true && blueLight == true && yellowLight == true)
        {
            elevatorActivated.SetActive(true);
        }
    }

    public void StateOn()
    {
        if(yellowButtonsPushed.Count >= buttonsNeeded)
        {
            yellowBridgeInactive.SetActive(false);
            yellowLightInactive.SetActive(false);
            yellowBridgeActive.SetActive(true);
            yellowLightActive.SetActive(true);
            yellowLight = true;
            uIYellowLight.SetActive(true);
        }

        if(blueButtonsPushed.Count >= buttonsNeeded)
        {
            blueBridgeInactive.SetActive(false);
            blueLightInactive.SetActive(false);
            blueBridgeActive.SetActive(true);
            blueLightActive.SetActive(true);
            blueLight = true;
            uIBlueLight.SetActive(true);
        }

        if(greenButtonsPushed.Count >= buttonsNeeded)
        {
            greenBridgeInactive.SetActive(false);
            greenLightInactive.SetActive(false);
            greenBridgeActive.SetActive(true);
            greenLightActive.SetActive(true);
            greenLight = true;
            uIGreenLight.SetActive(true);
        }
        
        if(redButtonsPushed.Count >= buttonsNeeded)
        {
            redBridgeInactive.SetActive(false);
            redLightInactive.SetActive(false);
            redBridgeActive.SetActive(true);
            redLightActive.SetActive(true);
            redLight = true;
            uIRedLight.SetActive(true);
        }

        if(orangeButtonsPushed.Count >= buttonsNeeded)
        {
            orangeBridgeInactive.SetActive(false);
            orangeBridgeActive.SetActive(true);
        }

        if(doorOneButtonsPushed.Count >= buttonsNeeded)
        {
            entraceDoor.SetActive(false);
        }

        if(doorTwoButtonsPushed.Count >= buttonsNeeded)
        {
            entranceBridgeInactive.SetActive(false);
            entranceBridgeActive.SetActive(true);
        }
    }

    public void StateOff()
    {
        if(yellowButtonsPushed.Count < buttonsNeeded)
        {
            yellowBridgeInactive.SetActive(true);
            yellowLightInactive.SetActive(true);
            yellowBridgeActive.SetActive(false);
            yellowLightActive.SetActive(false);
            yellowLight = false;
            uIYellowLight.SetActive(false);
        }

        if(blueButtonsPushed.Count < buttonsNeeded)
        {
            blueBridgeInactive.SetActive(true);
            blueLightInactive.SetActive(true);
            blueBridgeActive.SetActive(false);
            blueLightActive.SetActive(false);
            blueLight = false;
            uIBlueLight.SetActive(false);
        }
        
        if(greenButtonsPushed.Count < buttonsNeeded)
        {
            greenBridgeInactive.SetActive(true);
            greenLightInactive.SetActive(true);
            greenBridgeActive.SetActive(false);
            greenLightActive.SetActive(false);
            greenLight = false;
            uIGreenLight.SetActive(false);
        }

        if(redButtonsPushed.Count < buttonsNeeded)
        {
            redBridgeInactive.SetActive(true);
            redLightInactive.SetActive(true);
            redBridgeActive.SetActive(false);
            redLightActive.SetActive(false);
            redLight = false;
            uIRedLight.SetActive(false);
        }

        if(orangeButtonsPushed.Count < buttonsNeeded)
        {
            orangeBridgeInactive.SetActive(true);
            orangeBridgeActive.SetActive(false);
        }

        if(doorOneButtonsPushed.Count < buttonsNeeded)
        {
            entraceDoor.SetActive(true);
        }

        if(doorTwoButtonsPushed.Count < buttonsNeeded)
        {
            entranceBridgeInactive.SetActive(true);
            entranceBridgeActive.SetActive(false);
        }
    }
}
