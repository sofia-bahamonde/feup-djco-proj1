using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneTo(string scene)
    {
        if(scene == "exit")
        {
            Application.Quit();
        }else
            SceneManager.LoadScene(scene);
    }
}
