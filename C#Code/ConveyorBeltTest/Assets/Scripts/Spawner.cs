using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    private int objectCounter = 0;
    void Start()
    {
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

        var createdObject = Instantiate(newObject, randomPosition, Quaternion.identity, transform);
        createdObject.GetComponent<Rigidbody>().isKinematic = false;
        objectCounter++;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < 2)
        {
            SpawnObject();
        }
    }
}
