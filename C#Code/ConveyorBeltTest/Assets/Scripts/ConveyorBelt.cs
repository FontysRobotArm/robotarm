using System;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] 
    private float speed;
    [SerializeField] 
    private Vector3 direction;
    [SerializeField] 
    public List<GameObject> onBelt;
    private Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        for (int i = 0; i < onBelt.Count - 1; i++)
        {
            Rigidbody itemOnBelt = onBelt[i].GetComponent<Rigidbody>();
            Vector3 position = itemOnBelt.position;
        }
    }

    private void FixedUpdate()
    {
        // for (int i = 0; i <= onBelt.Count - 1; i++)
        // {
        //     rBody = onBelt[i].GetComponent<Rigidbody>();
        //     rBody.velocity = direction * speed;
        // }
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