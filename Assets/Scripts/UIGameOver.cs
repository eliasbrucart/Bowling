using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    public TMP_Text poitnsEarned;
    void Start()
    {
        
    }

    void Update()
    {
        poitnsEarned.text = "Points Earned: " + GameManager.instanceGameManager.GetPoints();
    }
}
