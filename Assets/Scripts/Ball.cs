using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public Vector3 startPos;
    public float limitMove;

    private bool isMoving;
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        transform.position = startPos;
        isMoving = false;
    }

    void Update()
    {
        if(transform.position.z >= limitMove)
        {
            ResetPos();
        }
    }

    public void AddForce()
    {
        rb.AddForce(new Vector3(0.0f, 0.0f, force));
        isMoving = true;
    }

    public void Right()
    {
        transform.position += new Vector3(1.0f, 0.0f, 0.0f);
    }

    public void Left()
    {
        transform.position += new Vector3(-1.0f, 0.0f, 0.0f);
    }

    public void ResetPos()
    {
        transform.position = startPos;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        isMoving = false;
    }
}
