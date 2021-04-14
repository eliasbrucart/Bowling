using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KegelsManager : MonoBehaviour
{
    public Kegel[] kegels;
    public int kegelAlive;
    public int kegelDead;

    public int points;
    void Start()
    {
        kegelAlive = kegels.Length;
        kegelDead = 0;
        points = 0;
    }

    void Update()
    {
        KegelAlive();
    }

    private void KegelAlive()
    {
        kegelAlive = kegels.Length;
        kegelDead = 0;
        points = 0;
        for(int i = 0; i < kegels.Length; i++)
        {
            if(kegels[i] != null)
            {
                if(!kegels[i].alive)
                {
                    kegelAlive--;
                    kegelDead++;
                    points += 10;
                }
            }
        }
    }
}
