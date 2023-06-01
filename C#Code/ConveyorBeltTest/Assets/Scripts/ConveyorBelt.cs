using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class ConveyorBelt : MonoBehaviour
{
    // private float speed = 5;
    [SerializeField] 
    private Vector3 direction;
    [SerializeField] 
    public List<GameObject> onBelt;
    public Rigidbody first;
    private Rigidbody rBody;

    public float length = 20;
    public float width = 5;
    public float speed = 5;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        GameObject thisObject = GameObject.Find("Conveyor belt scaler");
        // GameObject camera = GameObject.Find("Main Camera");

        GameObject conveyorLenghtObject = GameObject.Find("Canvas/MainMenu/ConveyorLength");
        GameObject conveyorWidthObject = GameObject.Find("Canvas/MainMenu/ConveyorWidth");
        GameObject conveyorSpeedObject = GameObject.Find("Canvas/MainMenu/ConveyorSpeed");
        String conveyorSpeedText = conveyorSpeedObject.GetComponent<TMP_InputField>().text;
        String conveyorLenghtText = conveyorLenghtObject.GetComponent<TMP_InputField>().text;
        String conveyorWidthText = conveyorWidthObject.GetComponent<TMP_InputField>().text;

        if (!string.IsNullOrEmpty(conveyorSpeedText)) 
        {
            speed = float.Parse(conveyorSpeedText);
        }
        
        if (!string.IsNullOrEmpty(conveyorLenghtText) && !string.IsNullOrEmpty(conveyorWidthText))
        {
            thisObject.transform.localScale = new Vector3(float.Parse(conveyorWidthText), 1, float.Parse(conveyorLenghtText));
            length = float.Parse(conveyorLenghtText);
            width = float.Parse(conveyorWidthText);
        }
        else
        {
            if (!string.IsNullOrEmpty(conveyorLenghtText))
            {
                thisObject.transform.localScale = new Vector3(5, 1, float.Parse(conveyorLenghtText));
                length = float.Parse(conveyorLenghtText);
            }
            else
            {
                thisObject.transform.localScale = new Vector3(5, 1, 20);
            }
            
            if (!string.IsNullOrEmpty(conveyorWidthText))
            {
                thisObject.transform.localScale = new Vector3(float.Parse(conveyorWidthText), 1);
                width = float.Parse(conveyorWidthText);
            }
            else
            {
                thisObject.transform.localScale = new Vector3(5, 1, 20);
            }
        }
        
        SceneManager.UnloadSceneAsync("Mainmenu");
    }

    private void Update()
    {
        // for (int i = 0; i < onBelt.Count - 1; i++)
        // {
        //     Rigidbody itemOnBelt = onBelt[i].GetComponent<Rigidbody>();
        //     first = itemOnBelt;
        // }
    }

    private void FixedUpdate()
    {
        if (onBelt.Count > 0)
        {
            for (int i = 0; i < onBelt.Count; i++)
            {
                Rigidbody itemOnBelt = onBelt[i].GetComponent<Rigidbody>();
                first = itemOnBelt;
            }
        }
        else
        {
            first = null;
        }

        Vector3 pos = rBody.position;
        rBody.position += direction * speed * Time.fixedDeltaTime;
        rBody.MovePosition(pos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        onBelt.Remove(collision.gameObject);
    }
}