using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTester : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    public GameObject objectToInstance;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 mousePos = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(mousePos);

        Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 200))
            {
                Instantiate(objectToInstance, hit.point, Quaternion.identity);
            }
            Debug.Log("Left Click");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
        }

        transform.LookAt(objectToInstance.transform);
    }
}
