using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private Vector3 minPosition = new Vector3(float.Parse("0.5"), 3, float.Parse("0.5"));
    private Vector3 maxPosition = new Vector3(float.Parse("5") - float.Parse("0.5"), 3, float.Parse("1.5"));
    private int objectCounter = 0;
    private int objectsToSpawn = 5;
    private float secondsBetweenSpawn = 1f;
    private float elapsedTime = 0.0f;
    private float objectWeight = 50f;
    void Start()
    {
        GameObject conveyorWidthObject = GameObject.Find("Canvas/MainMenu/ConveyorWidth");
        GameObject menuObjectsToSpawn = GameObject.Find("Canvas/MainMenu/SpawnerCount");
        GameObject menuSpawnerTime = GameObject.Find("Canvas/MainMenu/SpawnerTime");
        GameObject menuObjectWeight = GameObject.Find("Canvas/MainMenu/ObjectWeight");
        String conveyorWidthText = conveyorWidthObject.GetComponent<TMP_InputField>().text;
        String menuObjectsToSpawnText = menuObjectsToSpawn.GetComponent<TMP_InputField>().text;
        String menuSpawnerTimeText = menuSpawnerTime.GetComponent<TMP_InputField>().text;
        String menuObjectWeightText = menuObjectWeight.GetComponent<TMP_InputField>().text;
        
        if (!string.IsNullOrEmpty(conveyorWidthText))
        {
            maxPosition = new Vector3(float.Parse(conveyorWidthText) - float.Parse("0.5"), 3, float.Parse("1.5"));
        }
        if (!string.IsNullOrEmpty(menuObjectsToSpawnText))
        {
            objectsToSpawn = int.Parse(menuObjectsToSpawnText);
        }
        if (!string.IsNullOrEmpty(menuSpawnerTimeText))
        {
            secondsBetweenSpawn = float.Parse(menuSpawnerTimeText);
        }
        if (!string.IsNullOrEmpty(menuObjectWeightText))
        {
            objectWeight = float.Parse(menuObjectWeightText);
        }
        
        SpawnObject();
    }

    void SpawnObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
        );
        
        GameObject newObject = objectToSpawn;
        newObject.name =  "SpawnerCube" + objectCounter + "";
        newObject.GetComponent<Rigidbody>().mass = objectWeight;

        var createdObject = Instantiate(newObject, randomPosition, Quaternion.identity, transform);
        createdObject.GetComponent<Rigidbody>().isKinematic = false;
        objectCounter++;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < objectsToSpawn)
        {
            elapsedTime += Time.deltaTime;
 
            if (elapsedTime > secondsBetweenSpawn)
            {
                elapsedTime = 0;
                SpawnObject();
            }
        }
    }
}
