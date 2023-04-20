using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 minPosition;
    public Vector3 maxPosition;
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
        
        var createdObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity, transform);
        // createdObject.AddComponent<GetPositionObject>();
        createdObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < 1)
        {
            SpawnObject();
        }
    }
}
