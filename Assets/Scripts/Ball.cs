using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float force;

    public Vector3 startPos;
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        transform.position = startPos;
    }

    void Update()
    {

    }

    public void AddForce()
    {
        rb.AddForce(new Vector3(0.0f, 0.0f, force));
    }

    public void Right()
    {
        transform.position += new Vector3(1.0f, 0.0f, 0.0f);
    }

    public void Left()
    {
        transform.position += new Vector3(-1.0f, 0.0f, 0.0f);
    }
}
