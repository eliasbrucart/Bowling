﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public bool alive;
    void Start()
    {
        alive = true;
    }

    void Update()
    {
        
    }

    public bool CheckKegelAlive()
    {
        if (transform.rotation.x >= 0.5f || transform.rotation.x <= -0.5f || transform.rotation.z >= 0.5f || transform.rotation.z <= -0.5f)
        {
            alive = false;
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
