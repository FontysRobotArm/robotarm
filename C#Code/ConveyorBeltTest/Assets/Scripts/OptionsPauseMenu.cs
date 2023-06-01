using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsPauseMenu : MonoBehaviour
{
    public ConveyorBelt _conveyorBelt;
    public GameObject optionsPauseMenu;
    public static bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject thisObject = GameObject.Find("InGameCanvas");
        thisObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }   
    }

    public void PauseGame()
    {
        optionsPauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        GameObject conveyorSpeedObject = GameObject.Find("InGameCanvas/ConveyorSpeed");
        String conveyorSpeedText = conveyorSpeedObject.GetComponent<TMP_InputField>().text;

        if (conveyorSpeedText != "")
        {
            _conveyorBelt.speed = float.Parse(conveyorSpeedText);
        }

        optionsPauseMenu.SetActive(false);
        isPaused = false;
    }
    
    
    
}
