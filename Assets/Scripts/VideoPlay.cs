using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public float time;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(WaitAndLoad(time, nextScene));
    }

    private IEnumerator WaitAndLoad(float value, string scene)
    {
        yield return new WaitForSeconds(value);
        SceneManager.LoadScene(scene);
    }
}
