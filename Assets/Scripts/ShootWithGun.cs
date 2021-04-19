using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithGun : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

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

        Debug.DrawRay(ray.origin, ray.direction * 40, Color.yellow);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 40))
            {
                GameObject explosion = Instantiate(explosionGO, hit.point, Quaternion.identity);
                explosion.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
