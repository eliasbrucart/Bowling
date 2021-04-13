using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;

    public int tries;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ball.Left();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ball.Right();
        }
        if (Input.GetKeyDown(KeyCode.Space) && tries <= 3 && tries > 0 && !ball.isMoving && ball.force > 0)
        {
            ball.AddForce();
            tries--;
        }
        ResetTries();
    }

    void ResetTries()
    {
        if(tries <= 0)
        {
            tries = 0;
        }
    }
}
