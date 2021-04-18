using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    public TMP_Text poitnsEarned;
    public GameManager gm;
    void Start()
    {
        
    }

    void Update()
    {
        poitnsEarned.text = "Points Earned: " + gm.points;
    }
}
