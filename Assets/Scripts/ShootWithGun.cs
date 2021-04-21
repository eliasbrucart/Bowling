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

    [SerializeField] private int amountOfKegels;

    public Kegel kegelPrefab;
    public List<Kegel> miniKegels;

    [SerializeField] private int explosionForce;
    [SerializeField] private float timeToDestroy;

    public ScenesManager scenesManager;
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
            GameManager.instanceGameManager.tries--;
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, distanceRay))
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Kegel"))
                {
                    Rigidbody rigidBodyHit = hit.collider.gameObject.GetComponent<Rigidbody>();
                    rigidBodyHit.AddExplosionForce(explosionForce, hit.point, 2, 2, ForceMode.Impulse);
                    GameObject explosion = Instantiate(explosionGO, hit.point, Quaternion.identity, hit.transform);
                    explosion.GetComponent<ParticleSystem>().Play();
                    for (int i = 0; i < amountOfKegels; i++)
                    {
                        Kegel kegelGO = Instantiate(kegelPrefab, hit.transform.position, Quaternion.identity, hit.transform);
                        miniKegels.Add(kegelGO);
                    }

                    for (int i = 0; i < miniKegels.Count; i++)
                    {
                        if (miniKegels[i] != null)
                        {
                            miniKegels[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, hit.point, 2, 2, ForceMode.Impulse);
                        }
                    }
                }
                else
                {
                    scenesManager.ChangeScene("GameOver");
                }
            }
            for(int i=0; i < miniKegels.Count; i++)
            {
                if (miniKegels[i].timer <= timeToDestroy - 0.1f)
                    miniKegels[i].timer += Time.deltaTime;
                else
                {
                    miniKegels[i].timer = 0.0f;
                    Destroy(miniKegels[i].gameObject);
                }
            }
        }
    }
}
