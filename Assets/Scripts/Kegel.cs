using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public bool alive;
    public int points;
    void Start()
    {
        alive = true;
        points = 0;
    }

    void Update()
    {
        if (transform.rotation.x >= 0.5f || transform.rotation.x <= -0.5f || transform.rotation.z >= 0.5f || transform.rotation.z <= -0.5f)
        {
            alive = false;
            gameObject.SetActive(false);
            points += 10;
        }
    }
}
