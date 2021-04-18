using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Ball ball;
    public KegelsManager kegelsManager;
    public ScenesManager scenesManager;

    public int tries;
    public int points;

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
        points = 0;
    }

    void Update()
    {
        MoveBall();
        ThrowBall();
        kegelsManager.KegelAlive();
        Points();
        ResetTries();
        CheckGameOver();
    }

    void MoveBall()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ball.Left();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ball.Right();
        }
    }

    void ThrowBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tries <= 3 && tries > 0 && !ball.isMoving && ball.force > 0)
        {
            ball.AddForce();
            tries--;
        }
    }

    void Points()
    {
        points = 0;
        for (int i = 0; i < kegelsManager.kegels.Length; i++)
        {
            if (kegelsManager.kegels[i].CheckKegelAlive())
            {
                points += 10;
            }
        }
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
