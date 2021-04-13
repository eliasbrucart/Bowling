using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public Vector3 startPos;
    public float limitMove;

    public bool isMoving;

    private float moreForce = 5.0f;
    private float timeToReset;
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        transform.position = startPos;
        force = 0.0f;
        isMoving = false;
        timeToReset = 0.0f;
    }

    void Update()
    {
        timeToReset += Time.deltaTime;
        Debug.Log("timeToReset: " + timeToReset);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            force += moreForce;
        }
        if(force >= 0)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                force -= moreForce;
            }
        }
        if(force <= 0)
        {
            force = 0.0f;
        }
        if (transform.position.z >= limitMove || (timeToReset >= 10.0f && isMoving))
        {
            ResetPos();
            timeToReset = 0.0f;
        }
    }

    public void AddForce()
    {
        rb.AddForce(new Vector3(0.0f, 0.0f, force));
        isMoving = true;
        timeToReset = 0.0f;
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
