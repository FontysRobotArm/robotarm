using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ConveyorBelt : MonoBehaviour
{
    private float speed;
    [SerializeField] 
    private Vector3 direction;
    [SerializeField] 
    public List<GameObject> onBelt;
    public Rigidbody first;
    private Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        
        GameObject conveyorSpeedObject = GameObject.Find("Canvas/MainMenu/ConveyorSpeed");
        String conveyorSpeedText = conveyorSpeedObject.GetComponent<TMP_InputField>().text;

        if (!string.IsNullOrEmpty(conveyorSpeedText)) {
            speed = float.Parse(conveyorSpeedText);
        }
        else {
            speed = 5;
        }
        
        SceneManager.UnloadSceneAsync("Mainmenu");
    }

    private void Update()
    {
        Console.Out.WriteLine(onBelt);
        for (int i = 0; i < onBelt.Count - 1; i++)
        {
            Rigidbody itemOnBelt = onBelt[i].GetComponent<Rigidbody>();
            first = itemOnBelt;
        }
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