using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void onClickQuit()
    {
        Application.Quit();
    }
}
