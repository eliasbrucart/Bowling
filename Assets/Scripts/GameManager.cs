using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public KegelsManager kegelsManager;
    public ScenesManager scenesManager;

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
        CheckGameOver();
    }

    void ResetTries()
    {
        if(tries <= 0)
        {
            tries = 0;
        }
    }

    void CheckGameOver()
    {
        if ((kegelsManager.kegelAlive <= 0 || tries <= 0) && !ball.isMoving)
        {
            scenesManager.ChangeScene("GameOver");
        }
    }
}
