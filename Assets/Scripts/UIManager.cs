using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text textTries;
    public TMP_Text forceText;
    public TMP_Text aliveKegelsText;
    public TMP_Text pointsText;

    public GameManager gm;
    public Ball ball;
    public KegelsManager km;
    void Start()
    {
        
    }

    void Update()
    {
        textTries.text = "Tries: " + gm.tries;
        forceText.text = "Force: " + ball.force;
        aliveKegelsText.text = "Kegels Alive: " + km.kegelAlive;
        pointsText.text = "Points: " + gm.points;
    }
}
