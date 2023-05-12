using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject thisObject = GameObject.Find("Object Destroyer");

        GameObject conveyorLenghtObject = GameObject.Find("Canvas/MainMenu/ConveyorLength");
        GameObject conveyorWidthObject = GameObject.Find("Canvas/MainMenu/ConveyorWidth");
        String conveyorLenghtText = conveyorLenghtObject.GetComponent<TMP_InputField>().text;
        String conveyorWidthText = conveyorWidthObject.GetComponent<TMP_InputField>().text;

        if (!string.IsNullOrEmpty(conveyorLenghtText) && !string.IsNullOrEmpty(conveyorWidthText))
        {
            thisObject.transform.position = new Vector3(float.Parse(conveyorWidthText) / 2, float.Parse("-0.34"), float.Parse(conveyorLenghtText) + 5);
        }
        else
        {
            if (!string.IsNullOrEmpty(conveyorLenghtText))
            {
                thisObject.transform.position = new Vector3(float.Parse("2.5"), float.Parse("-0.34"), float.Parse(conveyorLenghtText) + 5);
            }
            else
            {
                thisObject.transform.position = new Vector3(float.Parse("2.5"), float.Parse("-0.34"), 25);
            }

            if (!string.IsNullOrEmpty(conveyorWidthText))
            {
                thisObject.transform.position =
                    new Vector3(float.Parse(conveyorWidthText) / 2, float.Parse("-0.34"), thisObject.transform.position.z);
            }
            else
            {
                thisObject.transform.position = new Vector3(float.Parse("2.5"), float.Parse("-0.34"), thisObject.transform.position.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider collider) 
    {
        Destroy(collider.gameObject);
    }
}
