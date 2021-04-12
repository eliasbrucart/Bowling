using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;

    public Transform ballTransform;
    void Start()
    {
        offset = new Vector3(0.0f, 3.0f, -7.0f);
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = ballTransform.position + offset;
    }
}
