using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SingeltonTest : MonoBehaviour
{
    private static SingeltonTest instance;

    public static SingeltonTest Instance { get { return instance; } }

    public int score;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
