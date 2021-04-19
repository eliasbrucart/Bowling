using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithGun : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private int distanceRay;

    [SerializeField]
    private int offsetCrossfire;

    public GameObject explosionGO;
    public GameObject crossfire;
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

        Debug.DrawRay(ray.origin, ray.direction * distanceRay, Color.yellow);
        crossfire.transform.position = ray.origin + (ray.direction * (distanceRay - offsetCrossfire));

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, distanceRay))
            {
                GameObject explosion = Instantiate(explosionGO, hit.point, Quaternion.identity);
                explosion.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
